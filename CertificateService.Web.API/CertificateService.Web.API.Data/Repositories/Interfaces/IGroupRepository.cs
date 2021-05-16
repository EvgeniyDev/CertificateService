using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetGroupsAsync();
        Task<Group> GetGroupByPredicateAsync(Expression<Func<Group, bool>> predicate);
        Task AddAsync(Group newGroup);
        Task UpdateAsync(Group group);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
