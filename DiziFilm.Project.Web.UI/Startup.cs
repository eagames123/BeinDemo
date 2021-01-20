using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using FluentValidation.AspNetCore;

namespace DiziFilm.Project.Web.UI
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAntiforgery(o => o.SuppressXFrameOptionsHeader = true);

            services.AddSession();

            //services.AddDistributedMemoryCache();

            services.AddMemoryCache();

            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = true;

                options.LowercaseUrls = true;

                options.LowercaseQueryStrings = true;
            });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.AddControllersWithViews().AddFluentValidation();

            services.AddSignalR();

            services.AddHttpContextAccessor();

            //Sayfa Refrehs için eklendi
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

        
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSession();
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseHsts();
            
            app.UseAuthorization();

            app.UseMvc();
            
        }
        
    }
}
