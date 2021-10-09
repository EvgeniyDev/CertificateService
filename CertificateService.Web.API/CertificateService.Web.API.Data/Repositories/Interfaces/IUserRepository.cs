using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    /// <summary>
    /// A repository for acces to users.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task<IEnumerable<User>> GetAllAsync();

        /// <summary>
        /// Gets user by specified predicate.
        /// </summary>
        /// <param name="predicate"><see cref="Expression{Func{User, bool}"/>.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task<User> GetByPredicateAsync(Expression<Func<User, bool>> predicate);

        /// <summary>
        /// Adds new <see cref="User"/>.
        /// </summary>
        /// <param name="newUser">A <see cref="User"/> to add.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task CreateAsync(User newUser);

        /// <summary>
        /// Updates existed <see cref="User"/>.
        /// </summary>
        /// <param name="user">A <see cref="User"/> to update.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task UpdateAsync(User user);

        /// <summary>
        /// Deletes existed <see cref="User"/>.
        /// </summary>
        /// <param name="id"><see cref="User"/>'s id.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Saves changes applied to context.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task SaveAsync();
    }
}
