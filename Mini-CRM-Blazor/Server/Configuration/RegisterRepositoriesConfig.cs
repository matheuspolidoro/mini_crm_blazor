using Mini_CRM_Blazor.Server.DAL.Repositories;

namespace Mini_CRM_Blazor.Server.Configuration
{
    public static class RegisterRepositoriesConfig
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<CompanySubscribersRepository>();
            services.AddScoped<ApplicationUsersRepository>();
            services.AddScoped<CustomersRepository>();

            return services;
        }

    }
}
