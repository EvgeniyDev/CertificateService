using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    /// <summary>
    /// A repository for acces to student's data.
    /// </summary>
    public interface IStudentDataRepository
    {
        /// <summary>
        /// Gets all student's data.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task<IEnumerable<StudentData>> GetStudentsDataAsync();

        /// <summary>
        /// Gets student's data by specified predicate.
        /// </summary>
        /// <param name="predicate"><see cref="Expression{Func{StudentData, bool}"/>.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task<StudentData> GetStudentDataByPredicateAsync(Expression<Func<StudentData, bool>> predicate);

        /// <summary>
        /// Adds new <see cref="StudentData"/>.
        /// </summary>
        /// <param name="newStudentData">A <see cref="StudentData"/> to add.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task AddAsync(StudentData newStudentData);

        /// <summary>
        /// Updates existed <see cref="StudentData"/>.
        /// </summary>
        /// <param name="studentData">A <see cref="StudentData"/> to update.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task UpdateAsync(StudentData studentData);

        /// <summary>
        /// Deletes existed <see cref="StudentData"/>.
        /// </summary>
        /// <param name="id"><see cref="StudentData"/>'s id.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Saves changes applied to context.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task SaveAsync();
    }
}
