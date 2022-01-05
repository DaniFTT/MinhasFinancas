using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhasFinancas.Application;
using MinhasFinancas.Application.Applications;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Domain.Interfaces.Services;
using MinhasFinancas.Domain.Services;
using MinhasFinancas.Infra.Data.Repository;
using MinhasFinancas.Infra.Data.Repository.Mock;

namespace MinhasFinancas.Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServices();
            services.RegisterAppServices();
            if (configuration.GetValue<bool>("MockRepositories"))
            {
                services.RegisterMockRepositories();
            }
            else
            {
                services.RegisterRepositories();
            }
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IMovementService, MovementService>();
            services.AddScoped<IWalletService, WalletService>();
        }

        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<ICategoryAppService, CategoryAppService>();

            services.AddAutoMapper(typeof(MappingProfile));
        }

        public static void RegisterMockRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, MockCategoryRepository>();
        }
    }
}