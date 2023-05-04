using Funix.HannahAssistant.Api.Common;
using Funix.HannahAssistant.Api.IManagers;
using Funix.HannahAssistant.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Funix.HannahAssistant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserManager UserManager { get; set; }
        public UserController(IUserManager userManager)
        {
            UserManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("Auth")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Auth([FromForm] LoginModel model)
        {
            try
            {
                return Ok(await UserManager.Auth(model.UserName, model.Password));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [Authorize]
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                return Ok(await UserManager.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [Authorize]
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(List<Guid> UserIds)
        {
            try
            {
                return Ok(await UserManager.Delete(UserIds));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [Authorize]
        [Consumes("application/x-www-form-urlencoded")]
        [HttpPost("AddEdit")]
        public async Task<IActionResult> AddEdit([FromForm] UserModel model)
        {
            try
            {
                return Ok(await UserManager.AddEdit(model));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [Authorize]
        [HttpGet("GetUserById/{UserId:guid}")]
        public async Task<IActionResult> GetUserById(Guid UserId)
        {
            try
            {
                return Ok(await UserManager.GetById(UserId));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [Authorize]
        [HttpGet("GetUserNotAssign")]
        public async Task<IActionResult> GetUserNotAssign()
        {
            try
            {
                return Ok(await UserManager.GetUserNotAssign());
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }
    }
}
