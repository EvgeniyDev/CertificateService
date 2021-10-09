using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    /// <summary>
    /// A repository for acces to students.
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task<IEnumerable<Student>> GetStudentsAsync();

        /// <summary>
        /// Gets student by specified predicate.
        /// </summary>
        /// <param name="predicate"><see cref="Expression{Func{Student, bool}"/>.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task<Student> GetStudentAsync(Expression<Func<Student, bool>> predicate);

        /// <summary>
        /// Adds new <see cref="Student"/>.
        /// </summary>
        /// <param name="newStudent">A <see cref="Student"/> to add.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task AddAsync(Student newStudent);

        /// <summary>
        /// Updates existed <see cref="Student"/>.
        /// </summary>
        /// <param name="student">A <see cref="Student"/> to update.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task UpdateAsync(Student student);

        /// <summary>
        /// Deletes existed <see cref="Student"/>.
        /// </summary>
        /// <param name="id"><see cref="Student"/>'s id.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Saves changes applied to context.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task SaveAsync();
    }
}
