using CertificateService.Web.API.Core.ViewModels.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Core.Services.Interfaces
{
    /// <summary>
    /// A service for manipulating user data.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Authenticates a user, provides a JWT Bearer token.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">User's password.</param>
        /// <returns>A <see cref="Task{UserViewModel}"/> representing asynchronus operation.</returns>
        Task<UserViewModel> Authenticate(string username, string password);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A <see cref="Task{IEnumerable{UserViewModel}"/> representing asynchronus operation.</returns>
        Task<IEnumerable<UserViewModel>> GetAll();

        /// <summary>
        /// Gets user by specified id.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns>A <see cref="Task{UserViewModel}"/> representing asynchronus operation.</returns>
        Task<UserViewModel> GetById(int id);
    }
}
