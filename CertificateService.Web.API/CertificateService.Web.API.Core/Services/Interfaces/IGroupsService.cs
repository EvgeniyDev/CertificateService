using CertificateService.Web.API.Core.ViewModels;
using CertificateService.Web.API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    /// <summary>
    /// A service for manipulating group data.
    /// </summary>
    public interface IGroupsService
    {
        /// <summary>
        /// Adds new group.
        /// </summary>
        /// <param name="newGroup">Group to add.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task AddAsync(AddGroupViewModel newGroup);

        /// <summary>
        /// Deletes existing group.
        /// </summary>
        /// <param name="id">Group id to be removed.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Updates existing group.
        /// </summary>
        /// <param name="group">Group data to update with.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task UpdateAsync(UpdateGroupViewModel group);

        /// <summary>
        /// Gets all groups.
        /// </summary>
        /// <returns>A <see cref="Task{IEnumerable{Group}"/> representing asynchronus operation.</returns>
        Task<IEnumerable<Group>> GetGroupsAsync();

        /// <summary>
        /// Gets group by specified id.
        /// </summary>
        /// <param name="id">Group id.</param>
        /// <returns>A <see cref="Task{Group}"/> representing asynchronus operation.</returns>
        Task<Group> GetGroupAsync(int id);

        /// <summary>
        /// Gets faculty by specified group name.
        /// </summary>
        /// <param name="groupName">Group name.</param>
        /// <returns>A <see cref="Task{Group}"/> representing asynchronus operation.</returns>
        Task<Group> GetGroupAsync(string groupName);

        /// <summary>
        /// Adds new students to existed group.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <param name="studentIds">Student ids'.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task AddStudentsToGroupAsync(int groupId, int[] studentIds);

        /// <summary>
        /// Removes existed students from group.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <param name="studentIds">Student ids'.</param>
        /// <returns>A <see cref="Task"/> representing asynchronus operation.</returns>
        Task RemoveStudentsFromGroupAsync(int groupId, int[] studentIds);

        /// <summary>
        /// Gets group name by student id.
        /// </summary>
        /// <param name="studentId">Student id.</param>
        /// <returns>A <see cref="Task{Group}"/> representing asynchronus operation.</returns>
        Task<Group> GetStudentGroupName(int studentId);
    }
}
