﻿using AutoMapper;
using Mini_CRM_Blazor.Server.Models;
using Mini_CRM_Blazor.Shared.Dtos;
using Mini_CRM_Blazor.Shared.Models;

namespace Mini_CRM_Blazor.Server.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(d => d.CustomerContacts, d => d.MapFrom(x => x.CustomerContacts));
            CreateMap<CustomerDto, Customer>();
        }
    }
}
