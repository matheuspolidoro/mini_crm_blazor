using AutoMapper;
using Microsoft.Extensions.Logging;
using Mini_CRM_Blazor.Server.DAL.Repositories;
using Mini_CRM_Blazor.Server.Models;
using Mini_CRM_Blazor.Server.Services.Base;
using Mini_CRM_Blazor.Shared.Dtos;
using Mini_CRM_Blazor.Shared.Enums;
using Mini_CRM_Blazor.Shared.Models;

namespace Mini_CRM_Blazor.Server.Services
{
    public class CustomerContactsService
    {
        private readonly CustomerContactsRepository _customersRepository;
        private readonly IMapper _mapper;
        public CustomerContactsService(CustomerContactsRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<CustomerContactDto>>> GetAllByCustomerId(Guid id)
        {
            var customers = await _customersRepository.GetAllByCustomerId(id);

            var response = _mapper.Map<CustomerContactDto[]>(customers);
            return new BaseResponse<IEnumerable<CustomerContactDto>>(response);
        }

        public async Task<BaseResponse<CustomerContactDto>> GetById(Guid id)
        {
            var customer = await _customersRepository.GetById(id);

            var response = _mapper.Map<CustomerContactDto>(customer);
            return new BaseResponse<CustomerContactDto>(response);
        }

        public async Task<BaseResponse<CustomerContactDto>> Add(CustomerContactCreateRequest model)
        {
            var customer = new CustomerContact
            {
                CustomerId = model.CustomerId,
                Sector = model.Sector,
                ContactInfo = model.ContactInfo,
                PersonResponsibleName = model.PersonResponsibleName,
                TypeContactId = model.TypeContactId
            };

            var createdCustomerContact = await _customersRepository.Add(customer);

            if (createdCustomerContact == null)
            {
                return new BaseResponse<CustomerContactDto>("Error on adding new contact info. Please try again.");
            }

            var response = _mapper.Map<CustomerContactDto>(createdCustomerContact);

            return new BaseResponse<CustomerContactDto>(response);
        }
    }
}
