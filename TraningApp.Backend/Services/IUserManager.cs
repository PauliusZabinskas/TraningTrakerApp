using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraningApp.Backend.Identity;

namespace TraningApp.Backend.Services
{
    public interface IUserManager<User>
    {
        Task<User> Register(RegisterRequest request);
        Task<User> Login(LoginRequest request);

    }

}