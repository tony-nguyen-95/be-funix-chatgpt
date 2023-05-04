using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IManagers;
using Funix.HannahAssistant.Api.IRepository;
using Funix.HannahAssistant.Api.Models;

namespace Funix.HannahAssistant.Api.Managers
{
    public class StudentManager : IStudentManager
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private IStudentRepository StudentRepository { get; set; }
        private IStudentContactRepository StudentContactRepository { get; set; }
        private IHannahStudentRepository HannahStudentRepository { get; set; }
        private ITempCertificateRepository TempCertificateRepository { get; set; }
        private ITempCourseRepository TempCourseRepository { get; set; }
        private ITempSubjectRepository TempSubjectRepository { get; set; }
        private ITempLessionRepository TempLessionRepository { get; set; }
        private ICertificateRepository CertificateRepository { get; set; }
        private ICourseRepository CourseRepository { get; set; }
        private ISubjectRepository SubjectRepository { get; set; }
        private ILessionRepository LessionRepository { get; set; }
        private ICoursePlanningWeeklyScheduleRepository CoursePlanningWeeklyScheduleRepository { get; set; }
        
        private IStudentCertificateRepository StudentCertificateRepository { get; set; }
        public StudentManager(IUnitOfWork unitOfWork, 
            IStudentRepository studentRepository, 
            IStudentContactRepository studentContactRepository,
            IHannahStudentRepository hannahStudentRepository,
            ITempCertificateRepository tempCertificateRepository,
            ICertificateRepository certificateRepository,
            IStudentCertificateRepository studentCertificateRepository,
            ITempCourseRepository tempCourseRepository,
            ITempSubjectRepository tempSubjectRepository,
            ITempLessionRepository tempLessionRepository,
            ICourseRepository courseRepository,
            ISubjectRepository subjectRepository,
            ILessionRepository lessionRepository,
            ICoursePlanningWeeklyScheduleRepository coursePlanningWeeklyScheduleRepository)
        {
            UnitOfWork = unitOfWork;
            StudentRepository = studentRepository;
            StudentContactRepository = studentContactRepository;
            HannahStudentRepository = hannahStudentRepository;
            TempCertificateRepository = tempCertificateRepository;
            CertificateRepository = certificateRepository;
            StudentCertificateRepository = studentCertificateRepository;
            TempCourseRepository = tempCourseRepository;
            TempSubjectRepository = tempSubjectRepository;
            TempLessionRepository = tempLessionRepository;
            CourseRepository = courseRepository;
            SubjectRepository = subjectRepository;
            LessionRepository = lessionRepository;
            CoursePlanningWeeklyScheduleRepository = coursePlanningWeeklyScheduleRepository;
        }

        public async Task<ApiStatusModel<List<StudentItem>>> GetStudents()
        {
            var students = await StudentRepository.Get();
            if (students != null && students.Count > 0)
            {
                return new ApiStatusModel<List<StudentItem>>()
                {
                    ReturnData = students.Select(x => new StudentItem() { 
                        StudentId = x.StudentId,
                        Name = x.Name,
                        Address = string.IsNullOrEmpty(x.Address) ? "" : x.Address,
                        FunixId = x.FunixId,
                        FunixEmail = x.FunixEmail,
                        HannahId = x.Hannahs != null && x.Hannahs.Count > 0 ? x.Hannahs.Where(y => y.IsSupport).FirstOrDefault().HannahId : Guid.Empty
                    }).ToList(),
                    ApiMessage = $"Lấy danh sách học viên thành công. Tổng cộng {students.Count()}",
                    ApiStatusCode = ApiStatusCode.OK
                };
            }
            return new ApiStatusModel<List<StudentItem>>()
            {
                ReturnData = null,
                ApiMessage = "Không tìm thấy dữ liệu.",
                ApiStatusCode = ApiStatusCode.Empty
            };
        }

        public async Task<ApiStatusModel<Student>> GetById(Guid StudentId)
        {
            var student = await StudentRepository.Get(StudentId);
            if (student != null)
                return new ApiStatusModel<Student>() { ReturnData = student, ApiStatusCode = ApiStatusCode.OK, ApiMessage = "" };
            return new ApiStatusModel<Student>()
            {
                ReturnData = null,
                ApiStatusCode = ApiStatusCode.Empty,
                ApiMessage = ""
            };
        }

        public async Task<ApiStatusModel<bool>> Delete(List<Guid> Ids)
        {
            var students = await StudentRepository.Get(Ids);
            if (students != null)
            {
                students.ForEach(x => x.IsDeleted = true);
                StudentRepository.Update(students);
                await UnitOfWork.CommitAsync();
            }
            return new ApiStatusModel<bool>()
            {
                ReturnData = true,
                ApiStatusCode = ApiStatusCode.OK,
                ApiMessage = "Xóa học viên thành công."
            };
        }

        public async Task<ApiStatusModel<bool>> AddEditContact(StudentContactModel model)
        {
            var student = await StudentRepository.Get(model.StudentId);
            if (student != null)
            {
                if (model.StudentContactId.Equals(Guid.Empty))
                {
                    var sContact = new StudentContact()
                    {
                        StudentContactId = Guid.NewGuid(),
                        Name = model.Name,
                        Note = "",
                        StudentId = model.StudentId,
                        Type = (ContactType)model.ContactType,
                        IsDeleted = false,
                    };
                    //Add
                    await StudentContactRepository.Add(sContact);
                }
                else
                {
                    var sContact = await StudentContactRepository.Get(model.StudentContactId);
                    if (sContact != null)
                    {
                        sContact.Name = model.Name;
                        sContact.Type = (ContactType)model.ContactType;
                        //Update
                        StudentContactRepository.Update(sContact);
                    }
                    else
                        return new ApiStatusModel<bool>() { ReturnData = false, ApiStatusCode = ApiStatusCode.Warning, ApiMessage = "Không tìm thấy liên lạc." };
                }
                //Commit
                await UnitOfWork.CommitAsync();
                return new ApiStatusModel<bool>()
                {
                    ReturnData = true,
                    ApiStatusCode = ApiStatusCode.OK,
                    ApiMessage = model.StudentContactId.Equals(Guid.Empty) ? "Thêm liên lạc cho học viên thành công." : "Chỉnh sửa liên lạc của học viên thành công."
                };
            }
            return new ApiStatusModel<bool>() {
                ReturnData = false,
                ApiStatusCode = ApiStatusCode.Warning,
                ApiMessage = "Không tìm thấy học viên."
            };
        }

        public async Task<ApiStatusModel<List<Student>>> GetStudentNotSupport()
        {
            var students = await StudentRepository.Get();
            var sNotSupport = await HannahStudentRepository.GetStudentNotSupport(students.Select(x => x.StudentId).ToList());
            return new ApiStatusModel<List<Student>>() { 
                ReturnData = sNotSupport != null && sNotSupport.Count > 0 ? sNotSupport.Select(x => x.Student).Distinct().ToList() : null,
                ApiStatusCode = sNotSupport != null && sNotSupport.Count > 0 ? ApiStatusCode.OK : ApiStatusCode.Empty,
                ApiMessage = sNotSupport != null && sNotSupport.Count > 0 ? "Lấy danh sách học viên chưa được thiết lập Hannah's hỗ trợ thành công." : "Không tìm thấy học viên."
            };
        }

        public async Task<ApiStatusModel<List<StudentContact>>> GetContactByStudentId(Guid StudentId)
        {
            var contacts = await StudentContactRepository.GetByStudentId(StudentId);
            if (contacts != null && contacts.Count > 0)
            {
                return new ApiStatusModel<List<StudentContact>>() { 
                    ReturnData = contacts,
                    ApiStatusCode = ApiStatusCode.OK,
                    ApiMessage = "Lấy danh sách liên lạc của học viên thành công."
                };
            }
            return new ApiStatusModel<List<StudentContact>>()
            {
                ReturnData = null,
                ApiStatusCode = ApiStatusCode.Empty,
                ApiMessage = "Không tìm thấy dữ liêu."
            };
        }

        public async Task<ApiStatusModel<bool>> DeleteContact(List<Guid> ContactIds)
        {
            var contacts = await StudentContactRepository.Get(ContactIds);
            if (contacts != null && contacts.Count > 0)
            {
                contacts.ForEach(x => x.IsDeleted = true);
                //Update
                StudentContactRepository.Update(contacts);
                //Commit
                await UnitOfWork.CommitAsync();
                return new ApiStatusModel<bool>() { ReturnData = true, ApiMessage = "Xóa liên lạc thành công.", ApiStatusCode = ApiStatusCode.OK };
            }
            return new ApiStatusModel<bool>() { 
                ReturnData = false, 
                ApiStatusCode = ApiStatusCode.Warning,
                ApiMessage = "Không tìm thấy liên lạc để xóa."
            };
        }

        public async Task<ApiStatusModel<bool>> AddEdit(StudentModel model)
        {
            if (model.StudentId.Equals(Guid.Empty))
            {
                var entity = new Student()
                {
                    StudentId = Guid.NewGuid(),
                    Name = model.Name,
                    FunixEmail = model.FunixMail,
                    FunixId = model.FunixId,
                    Status = (StudentStatus)model.Status,
                    IsDeleted = false,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                };
                //Add
                await StudentRepository.Add(entity);
            }
            else
            {
                var entity = await StudentRepository.Get(model.StudentId);
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.FunixEmail = model.FunixMail;
                    entity.FunixId = model.FunixId;
                    entity.UpdatedDate = DateTime.UtcNow;
                    entity.Status = (StudentStatus)model.Status;
                    //Update
                    StudentRepository.Update(entity);
                }
                else
                {
                    return new ApiStatusModel<bool>()
                    {
                        ReturnData = false,
                        ApiStatusCode = ApiStatusCode.Empty,
                        ApiMessage = "Không tìm thấy học viên."
                    };
                }
            }
            //Commit
            await UnitOfWork.CommitAsync();
            return new ApiStatusModel<bool>()
            {
                ReturnData = true,
                ApiStatusCode = ApiStatusCode.OK,
                ApiMessage = model.StudentId.Equals(Guid.Empty) ? "Thêm học viên thành công." : "Chỉnh sửa học viên thành công."
            };
        }

        public async Task<ApiStatusModel<bool>> AddLessionProgress(Guid LessionId, bool IsDone)
        {
            var lession = await LessionRepository.Get(LessionId);
            if (lession != null)
            {
                if (IsDone)
                    lession.DoneDate = DateTime.Now;
                else
                    lession.DoneDate = null;
                //Update
                LessionRepository.Update(lession);
                //Commit
                await UnitOfWork.CommitAsync();
                return new ApiStatusModel<bool>() { ReturnData = true, ApiStatusCode = ApiStatusCode.OK, ApiMessage = IsDone ? "Chuyển trạng thái thành Kết thúc bài học thành công." : "Chuyển trạng thái thành đang học thành công." };
            }
            return new ApiStatusModel<bool>() { 
                ReturnData = false,
                ApiStatusCode = ApiStatusCode.Empty,
                ApiMessage = "Không tìm thấy bài học."
            };
        }

        public async Task<ApiStatusModel<bool>> AddStudentCertificate(Guid StudentId, Guid TempCertificateId, DateTime StartDate)
        {
            var student = await StudentRepository.Get(StudentId);
            var tempCert = await TempCertificateRepository.Get(TempCertificateId);
            if (tempCert != null)
            {
                var tempCourses = (await TempCourseRepository.GetByCertificateId(TempCertificateId)).OrderBy(x => x.No).ToList();
                var cert = await CertificateRepository.GetByCode(tempCert.Code);
                if (cert == null)
                {
                    cert = new Certificate()
                    {
                        CertificateId = Guid.NewGuid(),
                        Code = tempCert.Code,
                        Name = tempCert.Name,
                        Description = "",
                        IsDeleted = false
                    };
                    //Add
                    await CertificateRepository.Add(cert);
                }
                //Add StudentCertificate
                int totalDaysPlanLearning = tempCourses.Sum(x => x.TotalWeekLearning) * 7;
                var sCertEntity = new StudentCertificate()
                {
                    CertificateId = cert.CertificateId,
                    StartDate = StartDate,
                    EndDate = null,
                    PlanStartDate = StartDate,
                    PlanEndDate = StartDate.AddDays(totalDaysPlanLearning),
                    StudentId = StudentId,
                };
                await StudentCertificateRepository.Add(sCertEntity);
                //Add Course
                var courses = new List<Course>();
                var subjects = new List<Subject>();
                var lessions = new List<Lession>();

                DateTime CourseStartDate = StartDate;
                foreach (var tempCourse in tempCourses)
                {
                    //Add Course
                    var course = new Course() {
                        CertificateId = cert.CertificateId,
                        CourseId = Guid.NewGuid(),
                        No = tempCourse.No,
                        Name = tempCourse.Name,
                        Code = tempCourse.Code,
                        Status = CourseStatus.Learning,
                        StartDate = null,
                        EndDate = null,
                        PlanStartDate = CourseStartDate,
                        PlanEndDate = CourseStartDate.AddDays(tempCourse.TotalWeekLearning * 7),
                        IsDeleted = false
                    };
                    courses.Add(course);
                    CourseStartDate = CourseStartDate.AddDays(tempCourse.TotalWeekLearning * 7);
                    //Add Subject
                    var tempSubjects = await TempSubjectRepository.GetByCourseId(tempCourse.TempCourseId);
                    foreach (var tempSubject in tempSubjects)
                    {
                        var subject = new Subject()
                        {
                            SubjectId = Guid.NewGuid(),
                            CourseId = course.CourseId,
                            No = tempSubject.No,
                            Name = tempSubject.Name,
                            Code = tempSubject.Code,
                            Description = "",
                            IsDeleted = false,
                            Status = SubjectStatus.Learning
                        };
                        subjects.Add(subject);
                        //Add Lession
                        var tempLessions = await TempLessionRepository.GetBySubjectId(tempSubject.TempSubjectId);
                        foreach (var tempLession in tempLessions)
                        {
                            lessions.Add(new Lession()
                            {
                                SubjectId = subject.SubjectId,
                                LessionId = Guid.NewGuid(),
                                No = tempLession.No,
                                Code = tempLession.Code,
                                Name = tempLession.Name,
                                Description = "",
                                DoneDate = null,
                                LessionType = (LessionType)(int)tempLession.Type,
                                Scores = 0,
                                IsDeleted = false,
                            });
                        }
                    }
                }
                if (courses != null && courses.Count > 0)
                    await CourseRepository.Add(courses);

                if (subjects != null && subjects.Count > 0)
                    await SubjectRepository.Add(subjects);

                if (lessions != null && lessions.Count > 0)
                    await LessionRepository.Add(lessions);

                //Commit
                await UnitOfWork.CommitAsync();
            }
            return new ApiStatusModel<bool>() { ReturnData = true, ApiStatusCode = ApiStatusCode.OK, ApiMessage = "" };
        }

        public async Task<ApiStatusModel<List<ListHannahStudentModel>>> GetStudentByHannah(Guid HannahId, DateTime StartDate, DateTime EndDate, int Status, bool IsSupport)
        {
            var result = new List<ListHannahStudentModel>();
            var hStudents = await HannahStudentRepository.Get(HannahId, StartDate, EndDate, Status, IsSupport);
            if (hStudents != null && hStudents.Count > 0)
            {
                foreach (var student in hStudents)
                {
                    var certificateLearning = await CertificateRepository.GetByStudentId(student.StudentId);
                    var lessionLearning = await LessionRepository.GetByStudentId(student.StudentId);
                    result.Add(new ListHannahStudentModel()
                    {
                        HannahStudentId = student.HannahStudentId,
                        StudentId = student.StudentId,
                        EndCertificateDate = null,
                        Certificate = certificateLearning != null ? certificateLearning.Name : "Chưa có chứng chỉ",
                        SubjectLessionLearning = lessionLearning != null ? lessionLearning.Name : "Chưa bắt đầu học",
                        FunixEmail = student.Student.FunixEmail,
                        FunixId = student.Student.FunixId,
                        Name = student.Student.Name,
                        SupportStartDate = student.StartDate,
                        Progress = await HandlerStudentProgress(student.StudentId),
                        Status = (int)student.Student.Status,
                        Contacts = (await StudentContactRepository.GetByStudentId(student.StudentId)).Select(x => new StudentContactModel() {
                            StudentContactId = x.StudentContactId,
                            ContactType = (int)x.Type,
                            Name = x.Name,
                            StudentId = x.StudentId
                        }).ToList(),
                    });
                }
            }
            return new ApiStatusModel<List<ListHannahStudentModel>>() {
                ReturnData = result.Count > 0 ? result : null,
                ApiStatusCode = result.Count > 0 ? ApiStatusCode.OK : ApiStatusCode.Empty,
                ApiMessage = result.Count > 0 ? "Tìm kiếm danh sách học viên thành công" : "Không tìm thấy danh sách học viên."
            };
        }


        /// <summary>
        /// 1 => Delay, 2 => OnSchedule, 3 => Over
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        private async Task<int> HandlerStudentProgress(Guid StudentId)
        {
            var coursesPlanning = await CoursePlanningWeeklyScheduleRepository.GetByStudentId(StudentId);
            if (coursesPlanning != null && coursesPlanning.Count > 0)
            {
                int totalLessionPlanning = coursesPlanning.Sum(x => x.TotalQuiz + x.TotalLab + x.TotalPT + x.TotalAss + x.TotalFinal);
                int totalDoneLession = (await LessionRepository.GetLessionDoneByStudentId(StudentId)).Count();
                if (totalLessionPlanning.Equals(totalDoneLession))
                    return 2;
                if (totalDoneLession > totalLessionPlanning)
                    return 3;
                if (totalDoneLession < totalLessionPlanning)
                    return 1;
            }
            return 0;
        }

        //TODO: Switch Hannah => HannahCurrentId => NewHannahId
        public async Task<ApiStatusModel<bool>> ChangeHannah(Guid StudentId, Guid CurrentHannahdId, Guid HannahId, DateTime StartDate)
        {
            //Update Hannah-Student
            var hStudentOld = await HannahStudentRepository.Get(CurrentHannahdId, StudentId);
            if (hStudentOld != null)
            {
                hStudentOld.IsSupport = false;
                hStudentOld.EndDate = StartDate;
                //Update
                HannahStudentRepository.Update(hStudentOld);
            }
            //Add New Hannah
            var hStudentNew = new HannahStudent()
            {
                HannahStudentId = Guid.NewGuid(),
                HannahId = HannahId,
                StudentId = StudentId,
                StartDate = StartDate,
                EndDate = StartDate.AddYears(1), //Default
                IsSupport = true
            };
            //Add
            await HannahStudentRepository.Add(hStudentNew);
            //Commit
            await UnitOfWork.CommitAsync();
            return new ApiStatusModel<bool>() { 
                ReturnData = true,
                ApiStatusCode = ApiStatusCode.OK,
                ApiMessage = "Thực hiện chuyển đổi Hannah để hỗ trợ thành công."
            };
        }
    }
}
