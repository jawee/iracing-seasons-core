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
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.HttpOverrides;

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
            services.AddCors();
            services.AddDbContext<IRacingLeagueScoringContext>(opt => opt.UseSqlite("Data Source=iracingleaguescoring.db"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "iRacing Season Scoring API", Version = "v1" });
            });

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
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            ); 
            app.UseMvc();
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "iRacing Season Scoring API");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
