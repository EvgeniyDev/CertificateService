using CertificateService.Web.API.Data.Context;
using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext appDBContext;

        public UserRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task Create(User user)
        {
            await appDBContext.Users.AddAsync(user);
            await SaveAsync();
        }

        public async Task Delete(int id)
        {
            var user = await GetByPredicate(u => u.Id == id);

            if (user != null)
            {
                appDBContext.Remove(user);
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await appDBContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByPredicate(Expression<Func<User, bool>> predicate)
        {
            return await appDBContext.Users.FirstOrDefaultAsync(predicate);
        }

        public async Task SaveAsync()
        {
            await appDBContext.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            appDBContext.Users.Update(user);
            await SaveAsync();
        }
    }
}
