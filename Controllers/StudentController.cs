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
    public class StudentController : ControllerBase
    {
        private IStudentManager StudentManager { get; set; }
        public StudentController(IStudentManager studentManager)
        {
            StudentManager = studentManager;
        }

        [HttpPost("AddEdit")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> AddEdit([FromForm] StudentModel model)
        {
            try
            {
                return Ok(await StudentManager.AddEdit(model));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                return Ok(await StudentManager.GetStudents());
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpGet("GetStudentNotSupport")]
        public async Task<IActionResult> GetStudentNotSupport()
        {
            try
            {
                return Ok(await StudentManager.GetStudentNotSupport());
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpGet("GetByStudentId/{StudentId:guid}")]
        public async Task<IActionResult> GetByStudentId(Guid StudentId)
        {
            try
            {
                return Ok(await StudentManager.GetById(StudentId));
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
                return Ok(await StudentManager.Delete(Ids));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpPost("DeleteContact")]
        public async Task<IActionResult> DeleteContact(List<Guid> Ids)
        {
            try
            {
                return Ok(await StudentManager.DeleteContact(Ids));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpPost("AddEditContact")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> AddEditContact([FromForm] StudentContactModel model)
        {
            try
            {
                return Ok(await StudentManager.AddEditContact(model));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpGet("GetContactByStudentId")]
        public async Task<IActionResult> GetContactByStudentId(Guid StudentId)
        {
            try
            {
                return Ok(await StudentManager.GetContactByStudentId(StudentId));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpPost("ChangeHannah")]
        public async Task<IActionResult> ChangeHannah(ChangeHannahModel model)
        {
            try
            {
                return Ok(await StudentManager.ChangeHannah(model.StudentId, model.CurrentHannahId, model.HannahId, model.StartDate));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpPost("GetStudentByHannah")]
        public async Task<IActionResult> GetStudentByHannah(GetStudentByHannahConditional model)
        {
            try
            {
                return Ok(await StudentManager.GetStudentByHannah(model.HannahId, model.StartDate, model.EndDate, model.Status, model.IsSupport));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpPost("AddStudentCertificate")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> AddStudentCertificate([FromForm] AddStudentCertificateModel model)
        {
            try
            {
                return Ok(await StudentManager.AddStudentCertificate(model.StudentId, model.TempCertificateId, model.StartDate));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }

        [HttpPost("AddLessionProgress")]
        public async Task<IActionResult> AddLessionProgress([FromBody] AddLessionProgressModel model)
        {
            try
            {
                return Ok(await StudentManager.AddLessionProgress(model.LessionId, model.IsDone));
            }
            catch (Exception ex)
            {
                return BadRequest(AppFunction.ReturnBadRequest(ex));
            }
        }
    }
}
