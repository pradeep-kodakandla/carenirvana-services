using CareNirvana.Service.Domain.Interface;
using CareNirvana.Service.Domain.Model;
using CareNirvana.Service.Infrastructure.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CareNirvana.Service.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public SecurityUser Authenticate(string username, string password)
        {
            var user = _userRepository.GetUser(username, password);
            if (user == null) return null;
            return user;
        }
    }
}

