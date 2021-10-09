using AutoMapper;
using CertificateService.Web.API.Core.Exceptions;
using CertificateService.Web.API.Core.Extensions;
using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels.Authorization;
using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using CertificateService.Web.API.Data.Resources;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IJwtTokenProviderService jwtTokenProviderService;

        public UserService(IMapper mapper, IUserRepository userRepository, IJwtTokenProviderService jwtTokenProviderService)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.jwtTokenProviderService = jwtTokenProviderService;
        }

        public async Task<UserViewModel> Authenticate(string username, string password)
        {
            // TODO: Hash password
            var user = await userRepository.GetByPredicate(u => u.Username.Equals(username) && u.Password.Equals(password));

            if (user == null)
            {
                var message = string.Format(ErrorMessages.NotFound, $"{typeof(User)} by requested username '{username}' was");
                throw new HttpStatusException(HttpStatusCode.NotFound, message);
            }

            var userVM = mapper.Map<UserViewModel>(user);
            userVM.Token = jwtTokenProviderService.CreateToken(user);

            return userVM.WithoutPassword();
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await userRepository.GetAll();

            return mapper.Map<IEnumerable<UserViewModel>>(users).WithoutPasswords();
        }

        public async Task<UserViewModel> GetById(int id)
        {
            var user = await userRepository.GetByPredicate(u => u.Id == id);

            if (user == null)
            {
                var message = string.Format(ErrorMessages.NotFound, $"{typeof(User)} by requested id '{id}' was");
                throw new HttpStatusException(HttpStatusCode.NotFound, message);
            }

            return mapper.Map<UserViewModel>(user).WithoutPassword();
        }
    }
}
