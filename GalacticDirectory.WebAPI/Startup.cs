﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalacticDirectory.DAL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GalacticDirectory.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<StarWarDBContext>(options =>
                                options.UseSqlServer(Configuration.GetConnectionString("StarWarCon"))
                                ,ServiceLifetime.Singleton);

            //  services.Add(new ServiceDescriptor(typeof(Models.Helpers.IGalacticHelper), new GalacticAPIHelper()));
            // Now let's register an API client for your AJAX call.
            // Includes the configuration - base address & content type.
            services.AddHttpClient("API Client", client =>
            {
                client.BaseAddress = new Uri("https://swapi.co/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            // Add the re-try policy: in this instance, re-try three times,
            // in 1, 3 and 5 seconds intervals.
            //.AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[] {
            //    TimeSpan.FromSeconds(1),
            //    TimeSpan.FromSeconds(5),
            //    TimeSpan.FromSeconds(10) })
            //);
            services.AddResponseCaching(options =>
            {
                options.MaximumBodySize = 1024;
                options.UseCaseSensitivePaths = true;
            });
            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("default", new CacheProfile
                {
                    Duration = 60,
                    Location = ResponseCacheLocation.Any
                });
            });
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
            }
            app.UseMvc();           
            app.UseResponseCaching();
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(60)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });
        }
    }
}
