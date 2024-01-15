using AutoMapper;
using Mini_CRM_Blazor.Server.Models;
using Mini_CRM_Blazor.Shared.Dtos;

namespace Mini_CRM_Blazor.Server.Mappings
{
    public class CustomerContactProfile : Profile
    {
        public CustomerContactProfile()
        {
            CreateMap<CustomerContact, CustomerContactDto>();
            CreateMap<CustomerContactDto, CustomerContact>();
        }
    }
}
