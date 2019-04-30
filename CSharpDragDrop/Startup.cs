using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpDragDrop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ShieldUI.AspNetCore.Mvc;

namespace CSharpDragDrop
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddShieldUI();

            Action<UpdateAC> list = (opt =>
            {
                opt.CountryList = GetCountries();
                opt.StatesList = GetStates();
            });
            services.Configure(list);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<UpdateAC>>().Value);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseShieldUI();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=DragDrop}/{id?}");
            });
        }

        public List<Country> GetCountries()
        {
            List<Country> countriesList = new List<Country>();
            for (int i = 0; i < 5; i++)
            {
                countriesList.Add(new Country
                {
                    Id = i + 1,
                    Name = "Country_" + (i + 1)
                });
            }

            return countriesList;
        }

        public List<State> GetStates()
        {
            Random rand = new Random();
            List<State> statesList = new List<State>();
            for (int i = 0; i < 20; i++)
            {
                statesList.Add(new State
                {
                    Id = i + 1,
                    Name = "State_" + (i + 1),
                    CountryId = rand.Next(1, 5)
                });
            }

            return statesList;
        }
    }
}
