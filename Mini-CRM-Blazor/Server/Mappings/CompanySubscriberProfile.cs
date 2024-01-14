using AutoMapper;
using Mini_CRM_Blazor.Server.Models;
using Mini_CRM_Blazor.Shared.Models;

namespace Mini_CRM_Blazor.Server.Mappings
{
    public class CompanySubscriberProfile : Profile
    {
        public CompanySubscriberProfile()
        {
            CreateMap<CompanySubscriber, CompanySubscriberDto>();
            CreateMap<CompanySubscriberDto, CompanySubscriber>();
        }
    }
}
