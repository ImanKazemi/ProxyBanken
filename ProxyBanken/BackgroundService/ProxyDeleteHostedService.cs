using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProxyBanken.Service.Interface;
using System;
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

            _logger.LogInformation("Starting Proxy Delete Hosted service");
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Proxy Delete Hosted service executing - {0}", DateTime.Now);
                var proxyProviderService = serviceProvider.GetRequiredService<IProxyService>();
                var configService = serviceProvider.GetRequiredService<IConfigService>();

                proxyProviderService.DeleteObsoleteProxy(int.Parse(configService.GetByName("ProxyDeleteInterval").Value));
                await Task.Delay(TimeSpan.FromDays(double.Parse(configService.GetByName("ProxyDeleteInterval").Value)), stoppingToken);
            }
        }
    }
}
