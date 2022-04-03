using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MinhasFinancas.Application.Applications;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Application.Interfaces.Services;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Domain.Interfaces.Services;
using MinhasFinancas.Domain.Services;
using MinhasFinancas.Infra.Data.Configurations;
using MinhasFinancas.Infra.Data.Repository;
using MinhasFinancas.Infra.Identity.Services;

namespace MinhasFinancas.Infra.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();


            services.AddHttpContextAccessor();
            services.RegisterServices();
            services.RegisterApplicationServices();
            services.RegisterRepositories();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IAdminSetupService, AdminSetupService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }

        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityAppService, IdentityAppService>();
            services.AddScoped<IAdminAppService, AdminAppService>();
            services.AddScoped<ICategoryAppService, CategoryAppService>();
        }
    }
}