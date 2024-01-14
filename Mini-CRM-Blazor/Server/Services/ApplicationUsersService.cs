using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mini_CRM_Blazor.Server.DAL.Repositories;
using Mini_CRM_Blazor.Server.Models;
using Mini_CRM_Blazor.Server.Services.Base;
using Mini_CRM_Blazor.Shared.Dtos;

namespace Mini_CRM_Blazor.Server.Services
{
    public class ApplicationUsersService
    {
        private readonly ApplicationUsersRepository _applicationUsersRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUsersService(
            ApplicationUsersRepository applicationUsersRepository,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationUsersRepository = applicationUsersRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<ApplicationUserDto>>> GetAll()
        {
            var applicationUser = await _applicationUsersRepository.GetAll();

            var response = _mapper.Map<ApplicationUserDto[]>(applicationUser);
            return new BaseResponse<IEnumerable<ApplicationUserDto>>(response);
        }

        public async Task<BaseResponse<ApplicationUserDto>> GetById(Guid id)
        {
            var applicationUser = await _applicationUsersRepository.GetById(id);

            var response = _mapper.Map<ApplicationUserDto>(applicationUser);
            return new BaseResponse<ApplicationUserDto>(response);
        }

        public async Task<BaseResponse<ApplicationUserDto>> GetByEmail(string email)
        {
            var applicationUser = await _applicationUsersRepository.GetByEmail(email);

            var response = _mapper.Map<ApplicationUserDto>(applicationUser);
            return new BaseResponse<ApplicationUserDto>(response);
        }

        public async Task<BaseResponse<ApplicationUser>> AddUserToRole(string userEmail, string role)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return new BaseResponse<ApplicationUser>("User not found.");
            }

            var identityResult = await _userManager.AddToRoleAsync(user, role);

            if (identityResult.Succeeded)
                return new BaseResponse<ApplicationUser>(user);

            return new BaseResponse<ApplicationUser>("Could not proceed. Try it again.");
        }
    }
}
