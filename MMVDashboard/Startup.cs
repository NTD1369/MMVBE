using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MMVDashboard.Application.Implements;
using MMVDashboard.Application.Interfaces;
using MMVDashboard.Data.Infrastructure;
using MMVDashboard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace MMVDashboard
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
            services.AddScoped<ConnectionFactory>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IKeySalesPerformanceService, KeySalesPerformanceService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IRegionService, RegionService>();



            services.AddControllers();
            //nén cho web nhẹ dung lượng hơn
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MMVDashboard", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddResponseCompression(options =>
            {
                IEnumerable<string> MimeTypes = new[]
                {
                        // General
                        "text/plain",
                        "text/html",
                        "text/css",
                        "font/woff2",
                        "application/javascript",
                        "image/x-icon",
                        "image/png"
                };

                options.EnableForHttps = true;
                options.ExcludedMimeTypes = MimeTypes;
                options.Providers.Add<BrotliCompressionProvider>();
                //options.Providers.Add<GzipCompressionProvider>();
                //options.Providers.Add<CustomCompressionProvider>();
                //options.MimeTypes =
                //    ResponseCompressionDefaults.MimeTypes.Concat(
                //        new[] { "image/svg+xml" });
            });
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MMVDashboard v1");
                c.RoutePrefix = "document";
                c.DocumentTitle = "RPFO.API v1";
                c.DefaultModelsExpandDepth(-1);
            });
            app.UseCors(x => x.WithOrigins().AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());
            //app.UseHttpsRedirection();
            app.UseResponseCompression(); // nén
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
