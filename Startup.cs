using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using iRacing_League_Scoring.Contexts;
using Microsoft.EntityFrameworkCore;
using iRacing_League_Scoring.Managers.Interfaces;
using iRacing_League_Scoring.Managers;

namespace iRacing_League_Scoring
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
            services.AddDbContext<IRacingLeagueScoringContext>(opt => opt.UseSqlite("Data Source=iracingleaguescoring.db"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<IDriverManager, DriverManager>();
            services.AddScoped<ISeasonManager, SeasonManager>();
            services.AddScoped<IRegisterRaceManager, RegisterRaceManager>();
            services.AddScoped<IRaceManager, RaceManager>();
            services.AddScoped<IRaceRowManager, RaceRowManager>();
            services.AddScoped<IPointCalculationManager, PointCalculationManager>();
            
            services.AddRouting();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
