using AutoMapper;
using Microsoft.Extensions.Logging;
using Mini_CRM_Blazor.Server.DAL.Repositories;
using Mini_CRM_Blazor.Server.Models;
using Mini_CRM_Blazor.Server.Services.Base;
using Mini_CRM_Blazor.Shared.Dtos;
using Mini_CRM_Blazor.Shared.Models;

namespace Mini_CRM_Blazor.Server.Services
{
    public class CustomersService
    {
        private readonly CustomersRepository _customersRepository;
        private readonly IMapper _mapper;
        public CustomersService(CustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<CustomerDto>>> GetAllByCompanySubscriberId(Guid id)
        {
            var customers = await _customersRepository.GetAllByCompanySubscriberId(id);

            var response = _mapper.Map<CustomerDto[]>(customers);
            return new BaseResponse<IEnumerable<CustomerDto>>(response);
        }

        public async Task<BaseResponse<CustomerDto>> GetById(Guid id)
        {
            var customer = await _customersRepository.GetById(id);

            var response = _mapper.Map<CustomerDto>(customer);
            return new BaseResponse<CustomerDto>(response);
        }

        public async Task<BaseResponse<CustomerDto>> Add(CustomerCreateRequest model)
        {
            var customer = new Customer
            {
                CompanySubscriberId = model.CompanySubscriberId,
                TradingName = model.TradingName,
                CompanyName = model.CompanyName,
                Description = model.Description,
                AreaOfBusiness = model.AreaOfBusiness,
                Website = model.Website,
            };

            var contacts = new List<CustomerContact>();

            if (model.Email != null)
                contacts.Add(new CustomerContact {
                    ContactInfo = model.Email,
                    TypeContact = Shared.Enums.TypeContacts.Email,
                });

            if (model.PhoneNumber != null)
                contacts.Add(new CustomerContact
                {
                    ContactInfo = model.Email,
                    TypeContact = Shared.Enums.TypeContacts.Email
                });
            
            customer.CustomerContacts = contacts;

            var createdCustomer = await _customersRepository.Add(customer);

            if (createdCustomer == null)
            {
                return new BaseResponse<CustomerDto>("Error on adding new customer. Please try again.");
            }

            var response = _mapper.Map<CustomerDto>(createdCustomer);

            return new BaseResponse<CustomerDto>(response);
        }
    }
}
