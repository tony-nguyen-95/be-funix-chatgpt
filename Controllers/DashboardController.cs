using Funix.HannahAssistant.Api.Common;
using Funix.HannahAssistant.Api.IManagers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Funix.HannahAssistant.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private IDashboardManager DashboardManager { get; set; }
        public DashboardController(IDashboardManager dashboardManager)
        {
            DashboardManager = dashboardManager;
        }

        [HttpGet("Get/{HannahId:guid}")]
        public async Task<IActionResult> Get(Guid HannahId)
        {
            try
            {
                return Ok(await DashboardManager.Get(HannahId));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }
    }
}
