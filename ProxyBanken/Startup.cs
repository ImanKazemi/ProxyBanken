using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;
using ProxyBanken.BackgroundService;
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
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient)
               ;

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IProxyRepository), typeof(ProxyRepository));
            services.AddScoped(typeof(IProxyTestRepository), typeof(ProxyTestRepository));
            services.AddScoped(typeof(IProxyProviderRepository), typeof(ProxyProviderRepository));
            services.AddScoped(typeof(IProxyTestServerRepository), typeof(ProxyTestServerRepository));
            services.AddScoped(typeof(IConfigRepository), typeof(ConfigRepository));

            services.AddTransient<IProxyService, ProxyService>();
            services.AddTransient<IProxyProviderService, ProxyProviderService>();
            services.AddTransient<IProxyTestServerService, ProxyTestServerService>();
            services.AddTransient<IProxyTestService, ProxyTestService>();
            services.AddTransient<IConfigService, ConfigService>();

            IMvcBuilder builder = services.AddRazorPages();
            services.AddHostedService<ProxyUpdateHostedService>();
            services.AddHostedService<ProxyDeleteHostedService>();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            services.AddRazorPages();

#if DEBUG
            if (Env.IsDevelopment())
            {
                builder.AddRazorRuntimeCompilation();
            }
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext dataContext)
        {

            dataContext.Database.Migrate();
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
