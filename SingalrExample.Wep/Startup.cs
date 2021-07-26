using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SingalrExample.Wep.Hubs;

namespace SingalrExample.Wep
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
            // erisim politikasini Cors uzerinden duzenliyoruz...
            // bu Server a hangi backendlerin erisebileceginin ayarlarini yapiyoruz
            // services.AddCors(options => options.AddDefaultPolicy(policy =>
            //     policy
            //         .AllowAnyMethod()
            //         .AllowAnyHeader()
            //         .AllowCredentials()
            //         .SetIsOriginAllowed(origin => true)
            //     
            //     ));
            services.AddCors(options => options.AddDefaultPolicy(policy =>
                policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetIsOriginAllowed(origin => true)));

            // singalR servisini kullanabilmek  icin ekliyoruzz.
            services.AddSignalR();

            services.AddRazorPages(); 
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors(); // yukarida default olarak olusturdugunuz cors ayarlarini burada kullanmak icin ekliyoruz

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // olusturdugumuz Hub icin endPoint olusturuyoruz

                //https://localhost:5001/myhub
                endpoints.MapHub<MyHub>("/myhub");
            });
        }
    }
}