using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Customers.Infrastructure.Data;
using Customers.Infrastructure.Extensions.ActionFilters;
using Customers.Infrastructure.Extensions.AutomapperMappingProfiles;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Customers.Api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc (opt => {
                    opt.Filters.Add (typeof (ValidatorActionFilter));
                }).AddFluentValidation ()
                .AddJsonOptions (options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddCors ();
            services.AddDbContext<CompanyContext> (options =>
                options.UseSqlServer (Configuration.GetConnectionString ("CompanyDatabase"),
                    b => b.MigrationsAssembly ("Customers.Api")));
            services.AddAutoMapper (x => x.AddProfile (new MappingProfiles ()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory> ().CreateScope ()) {
                if (!serviceScope.ServiceProvider.GetService<CompanyContext> ().AllMigrationsApplied ()) {
                    serviceScope.ServiceProvider.GetService<CompanyContext> ().Database.Migrate ();
                }
            }
            app.UseCors (x => x.AllowAnyHeader ().AllowAnyMethod ().AllowAnyOrigin ().AllowCredentials ());
            app.UseAuthentication ();

            app.UseMvc ();
        }
    }
}