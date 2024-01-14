using AutoMapper;
using Mini_CRM_Blazor.Server.DAL.Repositories;
using Mini_CRM_Blazor.Server.Models;
using Mini_CRM_Blazor.Server.Services.Base;
using Mini_CRM_Blazor.Shared.Dtos;
using Mini_CRM_Blazor.Shared.Models;

namespace Mini_CRM_Blazor.Server.Services
{
    public class CompanySubscribersService
    {
        private readonly CompanySubscribersRepository _companySubscribersRepository;
        private readonly IMapper _mapper;
        public CompanySubscribersService(CompanySubscribersRepository companySubscribersRepository, IMapper mapper)
        {
            _companySubscribersRepository = companySubscribersRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<CompanySubscriberDto>>> GetAll()
        {
            var companySubscriber = await _companySubscribersRepository.GetAll();

            var response = _mapper.Map<CompanySubscriberDto[]>(companySubscriber);
            return new BaseResponse<IEnumerable<CompanySubscriberDto>>(response);
        }

        public async Task<BaseResponse<CompanySubscriberDto>> GetById(Guid id)
        {
            var companySubscriber = await _companySubscribersRepository.GetById(id);

            var response = _mapper.Map<CompanySubscriberDto>(companySubscriber);
            return new BaseResponse<CompanySubscriberDto>(response);
        }

        public async Task<BaseResponse<CompanySubscriberDto>> Add(CompanySubscriberCreateRequest model)
        {
            // Verificar se o CPF já está em uso (opcional, dependendo dos requisitos)
            //var cpfExists = await _companySubscribersRepository.VerificarCpfExistente(model.Cpf);
            //if (cpfExists)
            //{
            //    return new BaseResponse<CompanySubscriberDto>("CPF já cadastrado.");
            //}

            var companySubscriber= new CompanySubscriber
            {
                TradingName = model.TradingName,
                CompanyName = model.CompanyName,
                Description = model.Description,
                AreaOfBusiness = model.AreaOfBusiness,
                Website = model.Website,
            };

            var createdCompanySubscriber = await _companySubscribersRepository.Add(companySubscriber);

            if (createdCompanySubscriber == null)
            {
                return new BaseResponse<CompanySubscriberDto>("Error on adding new company to subscription. Please try again.");
            }

            var response = _mapper.Map<CompanySubscriberDto>(createdCompanySubscriber);

            return new BaseResponse<CompanySubscriberDto>(response);
        }
    }
}
