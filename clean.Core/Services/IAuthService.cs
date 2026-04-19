using clean.Core.DTOs;
using clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Core.Services
{
    public interface IAuthService
    {
        Task<User> AuthenticateAsync(LoginModel loginModel);
    }
}
