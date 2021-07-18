using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<AppUser> Login(string userName, string password)
        {
           var user = await  _context.Users.FirstOrDefaultAsync(user => user.UserName == userName);
            if (user == null)
                return null;
            if (!VerifyPassword(user.PasswordHash,user.PasswordSalt,password))
                return null;
            return user;
          
        }
        private bool VerifyPassword(byte[] passwordHash , byte[] passwordSalt, string password)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
               var oldPasswordHash =  hmac.ComputeHash(UTF8Encoding.Unicode.GetBytes(password));
                for (int i = 0; i < oldPasswordHash.Length; i++)
                {
                    if (oldPasswordHash[i] != passwordHash[i])
                        return false;

                }
                return true;
            }
        }

        public async Task<AppUser> Registration(AppUser user, string password)
        {

            CreatePasswordHash(ref user, password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;


        }

        public async Task<bool> UserExist(string userName)
        {
            return !await _context.Users.AnyAsync(a => a.UserName == userName);
        }

        private void CreatePasswordHash(ref AppUser user, string password)
        {
            using (var hMACSHA = new HMACSHA512())
            {
                user.PasswordHash = hMACSHA.ComputeHash(UTF8Encoding.Unicode.GetBytes(password));
                user.PasswordSalt = hMACSHA.Key;


            }



        }
    }
}
