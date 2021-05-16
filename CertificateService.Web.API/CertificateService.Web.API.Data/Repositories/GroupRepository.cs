using CertificateService.Web.API.Data.Models;
using CertificateService.Web.API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDBContext appDBContext;

        public GroupRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task AddAsync(Group newGroup)
        {
            await appDBContext.Groups.AddAsync(newGroup);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var groupToDelete = await GetGroupByPredicateAsync(g => g.Id == id);

            if (groupToDelete != null)
            {
                appDBContext.Groups.Remove(groupToDelete);
                await SaveAsync();
            }
        }

        public async Task<Group> GetGroupByPredicateAsync(Expression<Func<Group, bool>> predicate)
        {
            return await appDBContext.Groups
                .Include(g => g.Students)
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await appDBContext.Groups
                .Include(g => g.Students).ThenInclude(s => s.StudentData)
                .Include(g => g.Students).ThenInclude(s => s.StudentTicket)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await appDBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Group group)
        {
            appDBContext.Update(group);
            await SaveAsync();
        }
    }
}
