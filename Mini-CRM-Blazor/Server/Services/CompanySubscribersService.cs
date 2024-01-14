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
        private readonly ApplicationUsersService _applicationUsersService;
        private readonly ApplicationUsersRepository _applicationUsersRepository;

        public CompanySubscribersService(CompanySubscribersRepository companySubscribersRepository, IMapper mapper, ApplicationUsersService applicationUsersService, ApplicationUsersRepository applicationUsersRepository)
        {
            _companySubscribersRepository = companySubscribersRepository;
            _mapper = mapper;
            _applicationUsersService = applicationUsersService;
            _applicationUsersRepository = applicationUsersRepository;
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
            var companySubscriber = new CompanySubscriber
            {
                TradingName = model.TradingName,
                CompanyName = model.CompanyName,
                Description = model.Description,
                AreaOfBusiness = model.AreaOfBusiness,
                Email = model.Email,
                Website = model.Website
            };

            var user = await _applicationUsersRepository.GetByEmail(model.ManagerEmail);
            if(user == null)
                return new BaseResponse<CompanySubscriberDto>("Add an existing user email.");

            var previousRoles = await _applicationUsersRepository.GetRolesFromUser(user);
            if (previousRoles.Count != 0)
                return new BaseResponse<CompanySubscriberDto>("User already in a organization.");

            var createdCompanySubscriber = await _companySubscribersRepository.Add(companySubscriber, user);

            if (createdCompanySubscriber == null)
            {
                return new BaseResponse<CompanySubscriberDto>("Error on adding new company to subscription. Please try again.");
            }

            var response = _mapper.Map<CompanySubscriberDto>(createdCompanySubscriber);

            return new BaseResponse<CompanySubscriberDto>(response);
        }
    }
}
