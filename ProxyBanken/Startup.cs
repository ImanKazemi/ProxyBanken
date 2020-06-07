using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProxyBanken.BackgroundService;
using ProxyBanken.Helper;
using ProxyBanken.Repository;
using ProxyBanken.Repository.Implementation;
using ProxyBanken.Repository.Interface;
using ProxyBanken.Service.Implementation;
using ProxyBanken.Service.Interface;

namespace ProxyBanken
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllersWithViews();

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IProxyRepository), typeof(ProxyRepository));
            services.AddScoped(typeof(IProxyTestRepository), typeof(ProxyTestRepository));
            services.AddScoped(typeof(IConfigRepository), typeof(ConfigRepository));

            services.AddTransient<IProxyService, ProxyService>();
            services.AddTransient<IProxyProviderService, ProxyProviderService>();
            services.AddTransient<IProxyTestUrlService, ProxyTestUrlService>();
            services.AddTransient<IProxyTestService, ProxyTestService>();
            services.AddTransient<IConfigService, ConfigService>();

            IMvcBuilder builder = services.AddRazorPages();
            services.AddHostedService<ProxyUpdateHostedService>();

#if DEBUG
            if (Env.IsDevelopment())
            {
                builder.AddRazorRuntimeCompilation();
            }
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
