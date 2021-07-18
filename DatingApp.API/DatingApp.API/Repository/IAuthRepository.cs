using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Repository
{
    public interface IAuthRepository
    {
        Task<AppUser> Registration(AppUser user, string password);
        Task<AppUser> Login(string userName, string password);
        Task<bool> UserExist(string userName);

    }
}
