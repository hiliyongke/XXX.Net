// ����������������������������������������������������������������������������������������������������������������������������
// ����   ����Startup.cs
// ����   �ߣ�YongkeLi
// ����   ����1.0
// ������ʱ�䣺2020 04 14 9:20
// ������ʱ�䣺2020 04 14 12:15
// ����������������������������������������������������������������������������������������������������������������������������

#region

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XXX.Net.Swagger;
using XXX.Net.Swagger.Options;

#endregion

namespace XXX.Net.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomSwagger(() =>
            {
                var xml = Configuration["Swagger:ApiXml"];
                return DefaultOptions.GetSwaggerOptions(xml);
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error");
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCustomSwagger(() =>
            {
                var xml = Configuration["Swagger:ApiXml"];
                return DefaultOptions.GetSwaggerOptions(xml);
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}