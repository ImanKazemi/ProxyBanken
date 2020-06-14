using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProxyBanken.DataAccess.Entity;
using ProxyBanken.Helper;
using ProxyBanken.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyBanken.BackgroundService
{
    public class ProxyUpdateHostedService : ScopedBackgroundService
    {
        private readonly ILogger<ProxyUpdateHostedService> _logger;
        public ProxyUpdateHostedService(IServiceScopeFactory serviceScopeFactory, ILogger<ProxyUpdateHostedService> logger) : base(serviceScopeFactory)
        {
            _logger = logger;
        }

        public override async Task ExecuteInScope(IServiceProvider serviceProvider, CancellationToken stoppingToken)
        {

            _logger.LogInformation("Starting Hosted service");

            //while (!stoppingToken.IsCancellationRequested)
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Hosted service executing - {0}", DateTime.Now);
                var proxyProviderService = serviceProvider.GetRequiredService<IProxyProviderService>();
                var serviceProviders = proxyProviderService.GetBaseProxies();

                var configService = serviceProvider.GetRequiredService<IConfigService>();

                Parallel.ForEach(serviceProviders, provider =>
                {
                    try
                    {
                        IList<Proxy> proxyList = ProxyHelper.StartCrawler(provider);
                        provider.LastFetchOn = DateTime.Now;
                        provider.LastFetchProxyCount = proxyList.Count;
                        provider.Exception = "";
                        var proxyService = serviceProvider.GetRequiredService<IProxyService>();

                        if (proxyList.Count > 0)
                        {
                            proxyService.BatchCreateOrUpdate(proxyList);

                            var proxyTestUrlService = serviceProvider.GetRequiredService<IProxyTestUrlService>();
                            IList<ProxyTest> proxyTestResults = ProxyHelper.TestProxies(proxyList.ToList(), proxyTestUrlService.GetTestUrls());

                            if (proxyTestResults.Count > 0)
                            {
                                var proxyTestService = serviceProvider.GetRequiredService<IProxyTestService>();
                                proxyTestService.BatchCreateOrUpdate(proxyTestResults);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        provider.LastFetchProxyCount = -1;
                        provider.Exception = ex.InnerException?.Message;
                    }

                    proxyProviderService.Update(provider);

                });
                proxyProviderService.SaveChanges();
                await Task.Delay(TimeSpan.FromMinutes(double.Parse(configService.GetByName("ProxyUpdateInterval").Value)), stoppingToken);
            }
        }
    }
}
