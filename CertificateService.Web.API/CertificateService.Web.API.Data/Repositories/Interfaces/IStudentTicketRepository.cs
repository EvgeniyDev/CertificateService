using CertificateService.Web.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Data.Repositories.Interfaces
{
    /// <summary>
    /// A repository for acces to student tickets.
    /// </summary>
    public interface IStudentTicketRepository
    {
        /// <summary>
        /// Gets all student tickets.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task<IEnumerable<StudentTicket>> GetStudentTicketsAsync();

        /// <summary>
        /// Gets student ticket by specified predicate.
        /// </summary>
        /// <param name="predicate"><see cref="Expression{Func{StudentTicket, bool}"/>.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task<StudentTicket> GetStudentTicketByPredicateAsync(Expression<Func<StudentTicket, bool>> predicate);

        /// <summary>
        /// Adds new <see cref="StudentTicket"/>.
        /// </summary>
        /// <param name="newStudentTicket">A <see cref="StudentTicket"/> to add.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task AddAsync(StudentTicket newStudentTicket);

        /// <summary>
        /// Updates existed <see cref="StudentTicket"/>.
        /// </summary>
        /// <param name="studentTicket">A <see cref="StudentTicket"/> to update.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task UpdateAsync(StudentTicket studentTicket);

        /// <summary>
        /// Deletes existed <see cref="StudentTicket"/>.
        /// </summary>
        /// <param name="id"><see cref="StudentTicket"/>'s id.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Saves changes applied to context.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task SaveAsync();
    }
}
