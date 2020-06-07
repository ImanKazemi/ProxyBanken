using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyBanken.BackgroundService
{
    public abstract class ScopedBackgroundService : Microsoft.Extensions.Hosting.BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        protected ScopedBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            await ExecuteInScope(scope.ServiceProvider, stoppingToken);
        }

        public abstract Task ExecuteInScope(IServiceProvider serviceProvider, CancellationToken stoppingToken);
    }
}
