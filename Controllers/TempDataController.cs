using Funix.HannahAssistant.Api.Common;
using Funix.HannahAssistant.Api.IManagers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Funix.HannahAssistant.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TempDataController : ControllerBase
    {
        private ITempDataManager TempDataManager { get; set; }
        public TempDataController(ITempDataManager tempDataManager)
        {
            TempDataManager = tempDataManager;
        }

        [HttpPost("SeedData")]
        public async Task<IActionResult> SeedData([FromBody] int CertIndex)
        {
            try
            {
                return Ok(await TempDataManager.SeedData(CertIndex));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpPost("AddLession")]
        public async Task<IActionResult> AddLession([FromBody] Guid CertificateId)
        {
            try
            {
                return Ok(await TempDataManager.AddLession(CertificateId));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpGet("GetTotalLessionByCourse")]
        public async Task<IActionResult> GetTotalLessionByCourse(Guid TempCourseId)
        {
            try
            {
                return Ok(await TempDataManager.GetTotalLessionByTempCourse(TempCourseId));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpGet("GetCertificates")]
        public async Task<IActionResult> GetCertificates()
        {
            try
            {
                return Ok(await TempDataManager.GetCertificates());
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }
    }
}
