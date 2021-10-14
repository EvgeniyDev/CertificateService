using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    /// <summary>
    /// A service for manipulating faculty data.
    /// </summary>
    public interface IFacultiesService
    {
        /// <summary>
        /// Adds new faculty.
        /// </summary>
        /// <param name="newFaculty">Faculty to add.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task AddAsync(AddFacultyViewModel newFaculty);

        /// <summary>
        /// Deletes existing faculty.
        /// </summary>
        /// <param name="id">Faculty id to be removed.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Updates existing faculty.
        /// </summary>
        /// <param name="faculty">Faculty data to update with.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task UpdateAsync(UpdateFacultyViewModel faculty);

        /// <summary>
        /// Gets all faculties.
        /// </summary>
        /// <returns>A <see cref="Task{IEnumerable{Faculty}"/> representing asynchronus operation.</returns>
        Task<IEnumerable<Faculty>> GetFacultiesAsync();

        /// <summary>
        /// Gets faculty by specified id.
        /// </summary>
        /// <param name="id">Faculty id.</param>
        /// <returns>A <see cref="Task{Faculty}"/> representing asynchronus operation.</returns>
        Task<Faculty> GetFacultyAsync(int id);

        /// <summary>
        /// Gets faculty by specified faculty number.
        /// </summary>
        /// <param name="number">Faculty id.</param>
        /// <returns>A <see cref="Task{Faculty}"/> representing asynchronus operation.</returns>
        Task<Faculty> GetFacultyByNumberAsync(int number);

        /// <summary>
        /// Adds new groups to existed faculty.
        /// </summary>
        /// <param name="facultyId">Faculty id.</param>
        /// <param name="groupIds">Group ids'.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task AddGroupsToFacultyAsync(int facultyId, int[] groupIds);

        /// <summary>
        /// Removes existed groups from faculty.
        /// </summary>
        /// <param name="facultyId">Faculty id.</param>
        /// <param name="groupIds">Group ids'.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task RemoveGroupsFromFacultyAsync(int facultyId, int[] groupIds);
    }
}
