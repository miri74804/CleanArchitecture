using clean.Core.DTOs;
using clean.Core.Entities;
using clean.Core.Repositories;
using clean.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepositoryManager _manager;
        public AuthService(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public async Task<User> AuthenticateAsync(LoginModel loginModel)
        {
            return await _manager.Users.GetUserByEmailAndPassword(loginModel.Email, loginModel.Password);
        }
    }
}
