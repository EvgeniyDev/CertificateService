using CertificateService.Web.API.Core.ViewModels.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace CertificateService.Web.API.Core.Extensions
{
    public static class UserExtensions
    {
        public static IEnumerable<UserViewModel> WithoutPasswords(this IEnumerable<UserViewModel> users)
        {
            if (users == null)
            {
                return null;
            }

            return users.Select(x => x.WithoutPassword());
        }

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
