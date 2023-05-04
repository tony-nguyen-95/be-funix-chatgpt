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
    public class CertificatesController : ControllerBase
    {
        private ICertificateManager CertificateManager { get; set; }
        public CertificatesController(ICertificateManager certificateManager)
        {
            CertificateManager = certificateManager;
        }

        [HttpGet("GetCourses/{StudentId:guid}/{CertificateId:guid}")]
        public async Task<IActionResult> GetCourses(Guid StudentId, Guid CertificateId)
        {
            try
            {
                return Ok(await CertificateManager.GetCourse(StudentId, CertificateId));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpGet("GetSubjects/{CertificateId:guid}")]
        public async Task<IActionResult> GetSubjects(Guid CourseId)
        {
            try
            {
                return Ok(await CertificateManager.GetSubject(CourseId));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpGet("GetLessions/{SubjectId:guid}")]
        public async Task<IActionResult> GetLessions(Guid SubjectId)
        {
            try
            {
                return Ok(await CertificateManager.GetLession(SubjectId));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpPost("AddCoursePlanningWeeklySchedule")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> AddCoursePlanningWeeklySchedule([FromForm] AddCoursePlanningWeeklyScheduleModel model)
        {
            try
            {
                return Ok(await CertificateManager.AddEditCourseWeeklySchedule(model));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }
    }
}
