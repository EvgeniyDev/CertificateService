using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetByPredicate(Expression<Func<User, bool>> predicate);
        Task Create(User user);
        Task Update(User user);
        Task Delete(int id);
        Task SaveAsync();
    }
}
