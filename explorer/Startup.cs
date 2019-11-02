using explorer.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Westwind.AspNetCore.LiveReload;
using ServiceProvider = explorer.Extensions.ServiceProvider;

namespace explorer
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLiveReload();
            services.AddControllersWithViews();
            services.AddSingleton<IStaticAssetsResolver, StaticAssetsResolver>();
            services.AddSingleton<WebpackAssets>();

            services.AddDbContext<ApplicationDbContext>(
              options => options.UseNpgsql(_configuration.GetConnectionString("psql")));



            services.AddTransient<IPostRepository, PostsRepository>();
            
            ServiceProvider.Setup(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseLiveReload();
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
                });
        }
    }
}