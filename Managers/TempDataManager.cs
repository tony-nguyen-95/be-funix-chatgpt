using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IManagers;
using Funix.HannahAssistant.Api.IRepository;
using Funix.HannahAssistant.Api.Models;

namespace Funix.HannahAssistant.Api.Managers
{
    public class TempDataManager : ITempDataManager
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private ITempCertificateRepository TempCertificateRepository { get; set; }
        private ITempCourseRepository TempCourseRepository { get; set; }
        private ITempSubjectRepository TempSubjectRepository { get; set; }
        private ITempLessionRepository TempLessionRepository { get; set; }
        private ITempCertificateCourseRepository TempCertificateCourseRepository { get; set; }
        public TempDataManager(ITempCertificateRepository tempCertificateRepository, 
            ITempCourseRepository tempCourseRepository, 
            ITempSubjectRepository tempSubjectRepository, 
            ITempLessionRepository tempLessionRepository,
            ITempCertificateCourseRepository tempCertificateCourseRepository,
            IUnitOfWork unitOfWork)
        {
            TempCertificateRepository = tempCertificateRepository;
            TempCourseRepository = tempCourseRepository;
            TempSubjectRepository = tempSubjectRepository;
            TempLessionRepository = tempLessionRepository;
            TempCertificateCourseRepository = tempCertificateCourseRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<ApiStatusModel<List<TempCertificate>>> GetCertificates()
        {
            var tempCerts = await TempCertificateRepository.GetCertificates();
            return new ApiStatusModel<List<TempCertificate>>() { 
                ReturnData = tempCerts != null && tempCerts.Count > 0 ? tempCerts : null,
                ApiStatusCode = tempCerts != null && tempCerts.Count > 0 ? ApiStatusCode.OK : ApiStatusCode.Empty,
                ApiMessage = tempCerts != null && tempCerts.Count > 0 ? "Lấy danh sách chứng chỉ thành công" : "Không tìm thấy dữ liệu."
            };
        }

        public async Task<ApiStatusModel<TotalLessionByCourse>> GetTotalLessionByTempCourse(Guid TempCourseId)
        {
            var model = new TotalLessionByCourse();
            var lession = await TempLessionRepository.GetByCourseId(TempCourseId);
            model.TotalQuiz = lession.Where(x => x.Type.Equals(TempLessionType.Quiz)).Count();
            model.TotalLab = lession.Where(x => x.Type.Equals(TempLessionType.Lab)).Count();
            model.TotalPT = lession.Where(x => x.Type.Equals(TempLessionType.ProgressTest)).Count();
            model.TotalAss = lession.Where(x => x.Type.Equals(TempLessionType.Assignment)).Count();
            model.TotalFinal = lession.Where(x => x.Type.Equals(TempLessionType.Final)).Count();
            return new ApiStatusModel<TotalLessionByCourse>() { ReturnData = model, ApiStatusCode = ApiStatusCode.OK, ApiMessage = "" };
        }

        public async Task<ApiStatusModel<bool>> AddLession(Guid CertificateId)
        {
            var courses = await TempCourseRepository.GetByCertificateId(CertificateId);
            foreach (var course in courses)
            {
                var subjects = await TempSubjectRepository.GetByCourseId(course.TempCourseId);
                var rd = new Random();
                if (subjects != null && subjects.Count > 0)
                {
                    int rdQuiz = rd.Next(3, 5);
                    int rdLab = rd.Next(2, 4);
                    int rdPT = rd.Next(0, 1);
                    int rdAss = rd.Next(0, 1);
                    var lession = new List<TempLession>();
                    foreach (var subject in subjects)
                    {
                        int index = 1;
                        if (subject.Equals(subjects.Last()))
                        {
                            lession.Add(AddTempLession(subject.TempSubjectId, index, TempLessionType.Final));
                        }
                        else
                        {
                            if (rdQuiz > 0)
                            {
                                for (int i = 1; i <= rdQuiz; i++)
                                {
                                    lession.Add(AddTempLession(subject.TempSubjectId, index, TempLessionType.Quiz));
                                    index++;
                                }
                            }
                            if (rdLab > 0)
                            {
                                for (int i = 1; i <= rdLab; i++)
                                {
                                    lession.Add(AddTempLession(subject.TempSubjectId, index, TempLessionType.Lab));
                                    index++;
                                }
                            }
                            if (rdPT > 0)
                            {
                                for (int i = 1; i <= rdPT; i++)
                                {
                                    lession.Add(AddTempLession(subject.TempSubjectId, index, TempLessionType.ProgressTest));
                                    index++;
                                }
                            }
                            if (rdAss > 0)
                            {
                                for (int i = 1; i <= rdAss; i++)
                                {
                                    lession.Add(AddTempLession(subject.TempSubjectId, index, TempLessionType.Assignment));
                                    index++;
                                }
                            }
                        }
                    }
                    //Add
                    await TempLessionRepository.Add(lession);
                    //Commit
                    await UnitOfWork.CommitAsync();
                }
            }
            return new ApiStatusModel<bool>() { ReturnData = true, ApiStatusCode = ApiStatusCode.OK, ApiMessage = "Thêm dữ liệu giả bài học thành công." };
        }

        private TempLession AddTempLession(Guid TempSubjectId, int index, TempLessionType lessionType)
        {
            return new TempLession()
            {
                TempLessionId = Guid.NewGuid(),
                TempSubjectId = TempSubjectId,
                No = index,
                Type = lessionType,
                Code = $"LESSION-00{index}",
                Name = $"Bài 0{index} - {lessionType.ToString()}",
                IsDeleted = false
            };
        }

        public async Task<ApiStatusModel<bool>> SeedData(int CertIndex)
        {
            var rd = new Random();
            var cert = new TempCertificate() {
                TempCertificateId = Guid.NewGuid(),
                Code = $"CC-00{CertIndex}",
                Name = $"Chứng chỉ 00{CertIndex}",
                IsDeleted = false,
            };
            var courses = new List<TempCourse>();
            int rdCourse = rd.Next(3, 5);
            for (int i = 1; i <= rdCourse; i++)
            {
                courses.Add(new TempCourse()
                {
                    TempCourseId = Guid.NewGuid(),
                    No = i,
                    Code = $"C-00{i.ToString()}",
                    Name = $"Khóa học 00{i.ToString()}",
                    IsDeleted = false
                });
            }

            var certCourse = new List<TempCertificateCourse>();
            foreach (var c in courses)
            {
                certCourse.Add(new TempCertificateCourse()
                {
                    TempCertificateCourseId = Guid.NewGuid(),
                    Code = $"{cert.Code}-{c.Code}",
                    Name = $"{cert.Name}-{c.Name}",
                    TempCertificateId = cert.TempCertificateId,
                    TempCourseId = c.TempCourseId,
                    IsDeleted = false
                });
            }
            //Todo::Add Cert
            await TempCertificateRepository.Add(cert);
            //Todo::Add Course
            await TempCourseRepository.Add(courses);
            //Todo::Add certCourse
            await TempCertificateCourseRepository.Add(certCourse);

            var subject = new List<TempSubject>();
            
            foreach (var c in courses)
            {
                int rdSubject = rd.Next(4, 6);
                for (int i = 1; i <= rdSubject; i++)
                {
                    subject.Add(new TempSubject()
                    {
                        TempSubjectId = Guid.NewGuid(),
                        No = i,
                        Code = $"S0{i.ToString()}",
                        Name = $"Môn học 0{i.ToString()}",
                        TempCourseId = c.TempCourseId,
                        IsDeleted = false
                    });
                }
            }
            //Add Subject
            await TempSubjectRepository.Add(subject);
            //Commit
            await UnitOfWork.CommitAsync();
            return new ApiStatusModel<bool>() {
                ReturnData = true,
                ApiStatusCode = ApiStatusCode.OK,
                ApiMessage = "Thêm dữ liệu giả thành công."
            };
        }
    }
}
