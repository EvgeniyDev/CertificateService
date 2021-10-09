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
    /// <inheritdoc cref="IGroupRepository"/>
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDBContext appDBContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupRepository"/> class.
        /// </summary>
        /// <param name="appDBContext"><see cref="AppDBContext"/>.</param>
        public GroupRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        /// <inheritdoc/>
        public async Task AddAsync(Group newGroup)
        {
            await appDBContext.Groups.AddAsync(newGroup);
            await SaveAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            var groupToDelete = await GetGroupByPredicateAsync(g => g.Id == id);

            if (groupToDelete != null)
            {
                appDBContext.Groups.Remove(groupToDelete);
                await SaveAsync();
            }
        }

        /// <inheritdoc/>
        public async Task<Group> GetGroupByPredicateAsync(Expression<Func<Group, bool>> predicate)
        {
            return await appDBContext.Groups
                .Include(g => g.Students)
                .FirstOrDefaultAsync(predicate);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await appDBContext.Groups
                .Include(g => g.Students).ThenInclude(s => s.StudentData)
                .Include(g => g.Students).ThenInclude(s => s.StudentTicket)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task SaveAsync()
        {
            await appDBContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(Group group)
        {
            appDBContext.Update(group);
            await SaveAsync();
        }
    }
}
