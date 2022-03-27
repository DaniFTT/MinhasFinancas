using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhasFinancas.Application;
using MinhasFinancas.Application.Applications;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Domain.Interfaces.Services;
using MinhasFinancas.Domain.Services;
using MinhasFinancas.Infra.Data.Repository;

namespace MinhasFinancas.Infra.IoC
{
    public static class NativeInjector
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServices();
            services.RegisterAppServices();
            services.RegisterRepositories();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddSingleton<IMovementRepository, MovementRepository>();
            services.AddSingleton<IWalletRepository, WalletRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddSingleton<IPaymentMethodService, PaymentMethodService>();
            services.AddSingleton<IMovementService, MovementService>();
            services.AddSingleton<IWalletService, WalletService>();
        }

        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationAppService, AuthenticationAppService>();
            services.AddTransient<ICategoryAppService, CategoryAppService>();

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}