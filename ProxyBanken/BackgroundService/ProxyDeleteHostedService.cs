using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Helper;
using ProxyBanken.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyBanken.BackgroundService
{
    public class ProxyDeleteHostedService : ScopedBackgroundService
    {
        private readonly ILogger<ProxyUpdateHostedService> _logger;
        public ProxyDeleteHostedService(IServiceScopeFactory serviceScopeFactory, ILogger<ProxyUpdateHostedService> logger) : base(serviceScopeFactory)
        {
            _logger = logger;
        }

        public override async Task ExecuteInScope(IServiceProvider serviceProvider, CancellationToken stoppingToken)
        {

            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken); // a wait to run website seperately

            _logger.LogInformation("Starting Proxy Delete Hosted service");
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Proxy Delete Hosted service executing - {0}", DateTime.Now);
                var proxyService = serviceProvider.GetRequiredService<IProxyService>();
                var configService = serviceProvider.GetRequiredService<IConfigService>();

                var expiredProxy = proxyService.GetExpiredProxies(int.Parse(configService.GetByName("ProxyDeleteInterval").Value));

                var deleteList = new List<Proxy>();
                var updateList = new List<Proxy>();

                Parallel.ForEach(expiredProxy, (proxy) =>
                 {
                     var ping = ProxyHelper.Ping(proxy.Ip);
                     if (ping.HasValue)
                     {
                         proxy.LastFunctionalityTestDate = ping;
                         updateList.Add(proxy);
                     }
                     else
                     {
                         deleteList.Add(proxy);
                     }
                 });

                proxyService.BatchCreateOrUpdate(updateList);
                proxyService.BatchDelete(deleteList);

                await Task.Delay(TimeSpan.FromDays(double.Parse(configService.GetByName("ProxyDeleteInterval").Value)), stoppingToken);
            }
        }
    }
}
