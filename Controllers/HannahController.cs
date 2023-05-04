using Funix.HannahAssistant.Api.Common;
using Funix.HannahAssistant.Api.IManagers;
using Funix.HannahAssistant.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Funix.HannahAssistant.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HannahController : ControllerBase
    {
        private IHannahManager HannahManager { get; set; }
        public HannahController(IHannahManager hannahManager)
        {
            HannahManager = hannahManager;
        }


        [HttpGet("GetHannahs")]
        public async Task<IActionResult> GetHannahs()
        {
            try
            {
                return Ok(await HannahManager.GetHannahs());
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(List<Guid> HannahIds)
        {
            try
            {
                return Ok(await HannahManager.Delete(HannahIds));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpPost("AddEdit")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> AddEdit([FromForm] HannahModel model)
        {
            try
            {
                return Ok(await HannahManager.AddEdit(model));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpGet("GetHannahById/{HannahId:guid}")]
        public async Task<IActionResult> GetHannahById(Guid HannahId)
        {
            try
            {
                return Ok(await HannahManager.GetById(HannahId));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(HannahStudentModel model)
        {
            try
            {
                return Ok(await HannahManager.AddStudent(model.HannahId, model.StudentIds, model.StartDate));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }
    }
}
