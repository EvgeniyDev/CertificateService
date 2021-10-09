using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    /// <summary>
    /// A repository for acces to groups.
    /// </summary>
    public interface IGroupRepository
    {
        /// <summary>
        /// Gets all groups.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task<IEnumerable<Group>> GetGroupsAsync();

        /// <summary>
        /// Gets groups by specified predicate.
        /// </summary>
        /// <param name="predicate"><see cref="Expression{Func{Group, bool}"/>.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task<Group> GetGroupByPredicateAsync(Expression<Func<Group, bool>> predicate);

        /// <summary>
        /// Adds new <see cref="Group"/>.
        /// </summary>
        /// <param name="newGroup">A <see cref="Group"/> to add.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task AddAsync(Group newGroup);

        /// <summary>
        /// Updates existed <see cref="Group"/>.
        /// </summary>
        /// <param name="group">A <see cref="Group"/> to update.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task UpdateAsync(Group group);

        /// <summary>
        /// Deletes existed <see cref="Group"/>.
        /// </summary>
        /// <param name="id"><see cref="Group"/>'s id.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Saves changes applied to context.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task SaveAsync();
    }
}
