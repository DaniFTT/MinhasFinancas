using MinhasFinancas.Infra.Identity.Configurations;
using MinhasFinancas.Infra.IoC;
using MinhasFinancas.Infra.Swagger;

namespace MinhasFinancas.WebApi
{
    public class Startup : Interfaces.IStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

            });
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSwaggerConfiguration();
            services.AddAuthentication(Configuration);
            services.RegisterServices(Configuration);
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(builder => builder
                .SetIsOriginAllowed(orign => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.MapControllers();
        }
    }
}
