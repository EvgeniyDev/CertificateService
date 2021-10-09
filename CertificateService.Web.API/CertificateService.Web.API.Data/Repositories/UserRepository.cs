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
    /// <inheritdoc cref="IUserRepository"/>
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext appDBContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="appDBContext"><see cref="AppDBContext"/>.</param>
        public UserRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        /// <inheritdoc/>
        public async Task CreateAsync(User user)
        {
            await appDBContext.Users.AddAsync(user);
            await SaveAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            var user = await GetByPredicateAsync(u => u.Id == id);

            if (user != null)
            {
                appDBContext.Remove(user);
                await SaveAsync();
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await appDBContext.Users.AsNoTracking().ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<User> GetByPredicateAsync(Expression<Func<User, bool>> predicate)
        {
            return await appDBContext.Users.FirstOrDefaultAsync(predicate);
        }

        /// <inheritdoc/>
        public async Task SaveAsync()
        {
            await appDBContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(User user)
        {
            appDBContext.Users.Update(user);
            await SaveAsync();
        }
    }
}
