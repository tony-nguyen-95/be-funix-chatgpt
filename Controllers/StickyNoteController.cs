using Funix.HannahAssistant.Api.Common;
using Funix.HannahAssistant.Api.IManagers;
using Funix.HannahAssistant.Api.Managers;
using Funix.HannahAssistant.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Funix.HannahAssistant.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StickyNoteController : ControllerBase
    {
        private IStickyNoteManager StickyNoteManager { get; set; }
        public StickyNoteController(IStickyNoteManager stickyNoteManager)
        {
            StickyNoteManager = stickyNoteManager;
        }

        [HttpGet("Get/{HannahId:guid}/{StudentId:guid}/{StartDate}/{EndDate}")]
        public async Task<IActionResult> Get(Guid HannahId, Guid StudentId, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                return Ok(await StickyNoteManager.Get(HannahId, StudentId, StartDate, EndDate));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpPost("AddEdit")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> AddEdit([FromForm] StickyNoteModel model)
        {
            try
            {
                return Ok(await StickyNoteManager.AddEdit(model));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(List<Guid> Ids)
        {
            try
            {
                return Ok(await StickyNoteManager.Delete(Ids));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }
    }
}
