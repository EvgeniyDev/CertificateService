using CertificateService.Web.API.Core.Services.Interfaces;
using CertificateService.Web.API.Core.ViewModels.Authorization;
using CertificateService.Web.API.Data.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CertificateService.Web.API.Controllers
{
    /// <summary>
    /// A controller for users manipulations.
    /// </summary>
    [Route("api/[controller]")]
    [Authorize(Roles = Constants.Role.Admin)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService"><see cref="IUserService"/>.</param>
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Authenticates anonymous API user by providing him JWT Bearer token.
        /// </summary>
        /// <param name="model">Data for authentication.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticationModel model)
        {
            var user = await userService.Authenticate(model.Username, model.Password);
            return Ok(user);
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await userService.GetAll();
            return Ok(users);
        }

        /// <summary>
        /// Gets user by specified id.
        /// </summary>
        /// <param name="id">Student id.</param>
        /// <returns>An async <see cref="IActionResult"/> with the response data.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Constants.Role.Admin))
            {
                return Forbid();
            }

            var user = await userService.GetById(id);

            return Ok(user);
        }
    }
}
