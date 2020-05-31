using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Org.Domain.Data.Repository;
using Org.Domain.Services;
using Org.Domain.Services.Interfaces;
using Org.Infrestructure.Data;
using Org.Infrestructure.Data.Repository;
using Org.Infrestructure.Profiles;
using Newtonsoft.Json.Serialization;

namespace Contract
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
            IServiceCollection serviceCollections = services.AddDbContext<SqlDBConttext>(o =>
            {
                o.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("ConnectionSqlServerAgencias"));
            });

            // configuration for JsonPatch
            services.AddControllers().AddNewtonsoftJson(c =>
            {
                c.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                c.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddAutoMapper(typeof(ClienteProfile));
            services.AddControllers();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
