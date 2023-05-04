using Funix.HannahAssistant.Api.Common;
using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IManagers;
using Funix.HannahAssistant.Api.IRepository;
using Funix.HannahAssistant.Api.Models;
using Funix.HannahAssistant.Api.Repository;

namespace Funix.HannahAssistant.Api.Managers
{
    public class CertificateManager : ICertificateManager
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private ICertificateRepository CertificateRepository { get; set; }
        private ICoursePlanningWeeklyScheduleRepository CoursePlanningWeeklyScheduleRepository { get; set; }
        private ICourseRepository CourseRepository { get; set; }
        private ISubjectRepository SubjectRepository { get; set; }
        public ILessionRepository LessionRepository { get; set; }
        public CertificateManager(IUnitOfWork unitOfWork, 
            ICertificateRepository certificateRepository, 
            ICourseRepository courseRepository, 
            ISubjectRepository subjectRepository, 
            ILessionRepository lessionRepository,
            ICoursePlanningWeeklyScheduleRepository coursePlanningWeeklyScheduleRepository)
        {
            UnitOfWork = unitOfWork;
            CertificateRepository = certificateRepository;
            CourseRepository = courseRepository;
            SubjectRepository = subjectRepository;
            LessionRepository = lessionRepository;
            CoursePlanningWeeklyScheduleRepository = coursePlanningWeeklyScheduleRepository;
        }

        public async Task<ApiStatusModel<List<Course>>> GetCourse(Guid StudentId, Guid CertificateId)
        {
            var courses = await CourseRepository.Get(StudentId, CertificateId);
            return new ApiStatusModel<List<Course>>() {
                ReturnData = courses != null && courses.Count > 0 ? courses : null,
                ApiStatusCode = courses != null && courses.Count > 0 ? ApiStatusCode.OK : ApiStatusCode.Empty,
                ApiMessage = ""
            };
        }

        public async Task<ApiStatusModel<List<Subject>>> GetSubject(Guid CourseId)
        {
            var subjects = await SubjectRepository.GetByCourseId(CourseId);
            return new ApiStatusModel<List<Subject>>() { 
                ReturnData = subjects != null && subjects.Count > 0 ? subjects : null,
                ApiStatusCode = subjects != null && subjects.Count > 0 ? ApiStatusCode.OK : ApiStatusCode.Empty,
                ApiMessage = ""
            };
        }

        public async Task<ApiStatusModel<List<Lession>>> GetLession(Guid SubjectId)
        {
            var lessions = await LessionRepository.GetBySubjectId(SubjectId);
            return new ApiStatusModel<List<Lession>>() {
                ReturnData = lessions != null && lessions.Count > 0 ? lessions : null,
                ApiStatusCode = lessions != null && lessions.Count > 0 ? ApiStatusCode.OK : ApiStatusCode.Empty,
                ApiMessage = ""
            };
        }

        public async Task<ApiStatusModel<bool>> AddEditCourseWeeklySchedule(AddCoursePlanningWeeklyScheduleModel model)
        {
            if (model.CoursePlanningWeeklyScheduleId.Equals(Guid.Empty))
            {
                var entity = new CoursePlanningWeeklySchedule()
                {
                    CoursePlanningWeeklyScheduleId = Guid.NewGuid(),
                    CourseId = model.CourseId,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    WeekOfYear = model.StartDate.GetIsoWeekOfYear(),
                    Year = model.StartDate.Year,
                    TotalQuiz = model.TotalQuiz,
                    TotalLab = model.TotalLab,
                    TotalPT = model.TotalPT,
                    TotalAss = model.TotalAss,
                    TotalFinal = model.TotalFinal
                };
                //Add
                await CoursePlanningWeeklyScheduleRepository.Add(entity);
            }
            else
            {
                var entity = await CoursePlanningWeeklyScheduleRepository.Get(model.CoursePlanningWeeklyScheduleId);
                if (entity != null)
                {
                    entity.StartDate = model.StartDate;
                    entity.EndDate = model.EndDate;
                    entity.WeekOfYear = model.StartDate.GetIsoWeekOfYear();
                    entity.Year = model.StartDate.Year;
                    entity.TotalQuiz = model.TotalQuiz;
                    entity.TotalLab = model.TotalLab;
                    entity.TotalPT = model.TotalPT;
                    entity.TotalAss = model.TotalAss;
                    entity.TotalFinal = model.TotalFinal;
                    //Update
                    CoursePlanningWeeklyScheduleRepository.Update(entity);
                }
                else
                {
                    return new ApiStatusModel<bool>()
                    {
                        ReturnData = false,
                        ApiStatusCode = ApiStatusCode.Empty,
                        ApiMessage = "Không tìm thấy thiết lập lịch kế hoạch học khóa học"
                    };
                }
            }
            //Commit
            await UnitOfWork.CommitAsync();
            return new ApiStatusModel<bool>()
            {
                ReturnData = true,
                ApiStatusCode = ApiStatusCode.OK,
                ApiMessage = model.CoursePlanningWeeklyScheduleId.Equals(Guid.Empty) ? "Thêm lịch kế hoạch học khóa học thành công." : "Chỉnh sửa lịch kế hoạch học khóa học thành công."
            };
        }
    }
}
