using CertificateService.Web.API.Core.ViewModels.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace CertificateService.Web.API.Core.Extensions
{
    /// <summary>
    /// Extensions for <see cref="UserViewModel"/>.
    /// </summary>
    public static class UserExtensions
    {
        /// <summary>
        /// Sets <see cref="UserViewModel"/>'s password to null for each element of collection.
        /// </summary>
        /// <param name="users"><see cref="IEnumerable{UserViewModel}"/>.</param>
        /// <returns>Collection of <see cref="UserViewModel"/>s with passwords equals null.</returns>
        public static IEnumerable<UserViewModel> WithoutPasswords(this IEnumerable<UserViewModel> users)
        {
            if (users == null)
            {
                return null;
            }

            return users.Select(x => x.WithoutPassword());
        }

        /// <summary>
        /// Sets <see cref="UserViewModel"/>'s password to null.
        /// </summary>
        /// <param name="user"><see cref="UserViewModel"/>.</param>
        /// <returns><see cref="UserViewModel"/> with password equals null.</returns>
        public static UserViewModel WithoutPassword(this UserViewModel user)
        {
            if (user != null)
            {
                user.Password = null;
            }

            return user;
        }
    }
}
