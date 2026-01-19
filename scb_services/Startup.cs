using lib_adapters.Adapters;
using lib_application.Ports;
using lib_application.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace scb_services
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static Microsoft.Extensions.Configuration.IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            // Adapters
            services.AddScoped<lib_application.Ports.IConfiguration, scb_services.Core.Configuration>();
            services.AddScoped<IConnection, Connection>();
            services.AddScoped<IAuditsRepository, AuditsRepository>();
            services.AddScoped<ITypesRepository, TypesRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            // Use Cases
            services.AddScoped<TypesUseCase, TypesUseCase>();
            services.AddScoped<ProductsUseCase, ProductsUseCase>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MapGet("/", () => "");
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}