using AutoMapper;
using Mini_CRM_Blazor.Server.Models;
using Mini_CRM_Blazor.Shared.Models;

namespace Mini_CRM_Blazor.Server.Configuration
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<CustomerDto, Customer>();

                cfg.CreateMap<CompanySubscriber, CompanySubscriberDto>();
                cfg.CreateMap<CompanySubscriberDto, CompanySubscriber>();

                //cfg.CreateMap<EntityFrom, EntityTo>()
                //    .ForMember(d => d.Name, d => d.MapFrom(x => x.OtherEntity.Name))

            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
