﻿using Mini_CRM_Blazor.Server.Services;

namespace Mini_CRM_Blazor.Server.Configuration
{
    public static class RegisterServicesConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<CompanySubscribersService>();
            services.AddScoped<ApplicationUsersService>();
            services.AddScoped<CustomersService>();
            services.AddScoped<CustomerContactsService>();

            return services;
        }

    }
}
