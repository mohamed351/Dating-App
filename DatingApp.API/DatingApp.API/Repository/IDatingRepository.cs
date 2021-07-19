using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Repository
{
    public interface IDatingRepository
    {
        void Add<T>(T Entity) where T : class;
        void Delete<T>(T Entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<AppUser>> GetAll();
        Task<AppUser> GetUser(int ID);




    }
    public class DatingRepository : IDatingRepository
    {
        private readonly ApplicationDbContext context;

        public DatingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add<T>(T Entity) where T : class
        {
            this.context.Add(Entity);
        }

        public void Delete<T>(T Entity) where T : class
        {
            this.context.Remove(Entity);
        }

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return  await this.context.Users.Include(a => a.Photos).ToListAsync();
        }

        public Task<IEnumerable<AppUser>> GetAll(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> GetUser(int ID)
        {
            return await this.context.Users.Include(a => a.Photos).FirstOrDefaultAsync(a=>a.ID == ID);
        }

       

        public async Task<bool> SaveAll()
        {
          return await this.context.SaveChangesAsync() > 0; 
        }
    }
}
