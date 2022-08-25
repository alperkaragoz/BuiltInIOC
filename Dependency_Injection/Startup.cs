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

            //// Default olarak de�il de �rne�in Transient olarak d�nd�rmek istiyorsak;
            ////Transient; gelen her talebe kar��l�k bir nesne �reterek geri d�nd�r
            ////services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog()/*,ServiceLifetime.Transient)*/));


            ////AddSingleton, AddTransient, AddScoped gibi metodlarla da kullanabiliyoruz.

            ////Singleton  --> Tek nesne �rne�ini t�m isteklere g�nderir.
            ////services.AddSingleton(typeof(ConsoleLog()));
            ////services.AddSingleton<ConsoleLog>(x=> new ConsoleLog(10));

            ////E�er constructor i�ine parametre al�yorsa a�a��daki gibi kullan�lamaz.
            //services.AddSingleton(typeof(TextLog), new TextLog());

            ////Scoped     --> T�m isteklerde ayr� bir nesne olu�turup, her bir iste�in talebine o nesneden g�nderecek.
            //services.AddScoped<ConsoleLog>();
            //services.AddScoped<ConsoleLog>(x => new ConsoleLog(5));

            //// Transient --> Her iste�in her talebine, talebe �zel nesne �retip g�nderecek.
            //services.AddTransient<ConsoleLog>(x => new ConsoleLog(10));

            //services.AddRazorPages();

            //Polimorphism kurallar�n�n ge�erli olaca�� �ekilde ILog interface'i olu�turduk, ConsoleLog ve TextLog'u ILog'tan t�rettik.
            services.AddScoped<ILog>(p => new ConsoleLog(10));

            //ILog t�r�nde container'a TextLog nesnesi ekliyor.
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
