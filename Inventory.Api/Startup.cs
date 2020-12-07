using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Domain.CatalogItemAggregate;
using Inventory.Domain.CatalogProviderAggregate;
using Inventory.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Inventory.Api
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Inventory.Api", Version = "v1"});
            });

            services.AddDbContext<AppDbContext>(builder =>
            {
                builder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), postgreOption =>
                {
                    postgreOption.MigrationsAssembly(typeof(Startup).Assembly.FullName);
                }).UseSnakeCaseNamingConvention();
            });
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            services.AddScoped<ICatalogItemRepository, CatalogItemRepository>();
            services.AddScoped<ICatalogProviderRepository, CatalogProviderRepository>();
            services.AddScoped<UnitOfWork>();
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddScoped<IDbConnection>(sp =>
            {
                return sp.GetRequiredService<AppDbContext>().Database.GetDbConnection();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}