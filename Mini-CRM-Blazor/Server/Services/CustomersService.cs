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
            // Verificar se o CPF já está em uso (opcional, dependendo dos requisitos)
            //var cpfExists = await _customersRepository.VerificarCpfExistente(model.Cpf);
            //if (cpfExists)
            //{
            //    return new BaseResponse<CustomerDto>("CPF já cadastrado.");
            //}

            var customer = new Customer
            {
                TradingName = model.TradingName,
                CompanyName = model.CompanyName,
                Description = model.Description,
                AreaOfBusiness = model.AreaOfBusiness,
                Website = model.Website,
                CustomerContacts = _mapper.Map<CustomerContact[]>(model.CustomerContacts)
            };

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
