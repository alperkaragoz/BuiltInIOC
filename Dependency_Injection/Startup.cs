using Dependency_Injection.Services;
using Dependency_Injection.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency_Injection
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

            ////Default olarak singleton olarak eklenir.
            ////services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog())));

            //// Default olarak deðil de örneðin Transient olarak döndürmek istiyorsak;
            ////Transient; gelen her talebe karþýlýk bir nesne üreterek geri döndür
            ////services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog()/*,ServiceLifetime.Transient)*/));


            ////AddSingleton, AddTransient, AddScoped gibi metodlarla da kullanabiliyoruz.

            ////Singleton  --> Tek nesne örneðini tüm isteklere gönderir.
            ////services.AddSingleton(typeof(ConsoleLog()));
            ////services.AddSingleton<ConsoleLog>(x=> new ConsoleLog(10));

            ////Eðer constructor içine parametre alýyorsa aþaðýdaki gibi kullanýlamaz.
            //services.AddSingleton(typeof(TextLog), new TextLog());

            ////Scoped     --> Tüm isteklerde ayrý bir nesne oluþturup, her bir isteðin talebine o nesneden gönderecek.
            //services.AddScoped<ConsoleLog>();
            //services.AddScoped<ConsoleLog>(x => new ConsoleLog(5));

            //// Transient --> Her isteðin her talebine, talebe özel nesne üretip gönderecek.
            //services.AddTransient<ConsoleLog>(x => new ConsoleLog(10));

            //services.AddRazorPages();

            //Polimorphism kurallarýnýn geçerli olacaðý þekilde ILog interface'i oluþturduk, ConsoleLog ve TextLog'u ILog'tan türettik.
            services.AddScoped<ILog>(p => new ConsoleLog(10));

            //ILog türünde container'a TextLog nesnesi ekliyor.
            services.AddScoped<ILog, TextLog>();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
