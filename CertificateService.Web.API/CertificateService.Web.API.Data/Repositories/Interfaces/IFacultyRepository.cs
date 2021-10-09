using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    /// <summary>
    /// A repository for acces to faculties.
    /// </summary>
    public interface IFacultyRepository
    {
        /// <summary>
        /// Gets all faculties.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task<IEnumerable<Faculty>> GetFacultiesAsync();

        /// <summary>
        /// Gets faculties by specified predicate.
        /// </summary>
        /// <param name="predicate"><see cref="Expression{Func{Faculty, bool}"/>.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task<Faculty> GetFacultyByPredicateAsync(Expression<Func<Faculty, bool>> predicate);

        /// <summary>
        /// Adds new <see cref="Faculty"/>.
        /// </summary>
        /// <param name="newFaculty">A <see cref="Faculty"/> to add.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task AddAsync(Faculty newFaculty);

        /// <summary>
        /// Updates existed <see cref="Faculty"/>.
        /// </summary>
        /// <param name="faculty">A <see cref="Faculty"/> to update.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task UpdateAsync(Faculty faculty);

        /// <summary>
        /// Deletes existed <see cref="Faculty"/>.
        /// </summary>
        /// <param name="id"><see cref="Faculty"/>'s id.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Saves changes applied to context.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task SaveAsync();
    }
}
