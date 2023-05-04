using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IManagers;
using Funix.HannahAssistant.Api.IRepository;
using Funix.HannahAssistant.Api.Models;

namespace Funix.HannahAssistant.Api.Managers
{
    public class HannahManager : IHannahManager
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private IHannahRepository HannahRepository { get; set; }
        private IHannahStudentRepository HannahStudentRepository { get; set; }
        public HannahManager(IUnitOfWork unitOfWork, 
            IHannahRepository hannahRepository,
            IHannahStudentRepository hannahStudentRepository) {
            UnitOfWork = unitOfWork;
            HannahRepository = hannahRepository;
            HannahStudentRepository = hannahStudentRepository;
        }

        public async Task<ApiStatusModel<List<HannahItem>>> GetHannahs()
        {
            var hannahs = await HannahRepository.Get();
            if (hannahs != null && hannahs.Count > 0)
            {
                return new ApiStatusModel<List<HannahItem>>()
                {
                    ReturnData = hannahs.Select(x => new HannahItem() {
                        HannahId = x.HannahId,
                        Name = x.Name,
                        Email = string.IsNullOrEmpty(x.Email) ? "" : x.Email,
                        PhoneNumber = string.IsNullOrEmpty(x.PhoneNumber) ? "" : x.PhoneNumber,
                        Address = "",
                        TotalStudentSupport = x.Students != null ? x.Students.Where(x => x.IsSupport).Count() : 0
                        
                    }).ToList(),
                    ApiMessage = $"Lấy Hannah thành công. Total {hannahs.Count()}",
                    ApiStatusCode = ApiStatusCode.OK
                };
            }
            return new ApiStatusModel<List<HannahItem>>()
            {
                ReturnData = null,
                ApiMessage = "Empty data.",
                ApiStatusCode = ApiStatusCode.Empty
            };
        }

        public async Task<ApiStatusModel<Hannah>> GetById(Guid HannahId)
        {
            var user = await HannahRepository.Get(HannahId);
            if (user != null)
            {
                return new ApiStatusModel<Hannah>()
                {
                    ReturnData = user,
                    ApiMessage = "Lấy Hannah thành công.",
                    ApiStatusCode = ApiStatusCode.OK
                };
            }
            return new ApiStatusModel<Hannah>()
            {
                ReturnData = null,
                ApiStatusCode = ApiStatusCode.Empty,
                ApiMessage = "Không tìm thấy Hannah."
            };
        }

        public async Task<ApiStatusModel<bool>> Delete(List<Guid> Ids)
        {
            var hannahs = await HannahRepository.Get(Ids);
            if (hannahs != null)
            {
                hannahs.ForEach(x => x.IsDeleted = true);
                HannahRepository.Update(hannahs);
                await UnitOfWork.CommitAsync();
            }
            return new ApiStatusModel<bool>()
            {
                ReturnData = true,
                ApiStatusCode = ApiStatusCode.OK,
                ApiMessage = "Delete logic successfully."
            };
        }

        //TODO: Add Students => One Hannah add Many Students
        public async Task<ApiStatusModel<bool>> AddStudent(Guid HannahId, List<Guid> StudentIds, DateTime StartDate)
        {
            var entities = new List<HannahStudent>();
            var sSupport = await HannahStudentRepository.GetStudentSupport(StudentIds);
            if (sSupport != null && sSupport.Count > 0)
            {
                var existSupport = sSupport.Select(x => x.StudentId).ToList();
                foreach (var student in StudentIds)
                {
                    if (!existSupport.Contains(student))
                    {
                        entities.Add(new HannahStudent()
                        {
                            HannahStudentId = Guid.NewGuid(),
                            HannahId = HannahId,
                            StudentId = student,
                            StartDate = StartDate,
                            EndDate = StartDate.AddYears(1), //Default
                            IsSupport = true
                        });
                    }
                }
            }
            else
            {
                foreach (var student in StudentIds)
                {
                    entities.Add(new HannahStudent()
                    {
                        HannahStudentId = Guid.NewGuid(),
                        HannahId = HannahId,
                        StudentId = student,
                        StartDate = StartDate,
                        EndDate = StartDate.AddYears(1), //Default
                        IsSupport = true
                    });
                }
            }
            if (entities != null && entities.Count > 0)
            {
                await HannahStudentRepository.Add(entities);
                //Commit
                await UnitOfWork.CommitAsync();
                return new ApiStatusModel<bool>()
                {
                    ReturnData = true,
                    ApiStatusCode = ApiStatusCode.OK,
                    ApiMessage = "Thêm Hannah để hỗ trợ học tập cho các học viên thành công."
                };
            }
            return new ApiStatusModel<bool>()
            {
                ReturnData = false,
                ApiStatusCode = ApiStatusCode.Empty,
                ApiMessage = "Không tìm thấy học viên đủ điều kiện để thêm hỗ trợ của Hannah."
            };
        }

        public async Task<ApiStatusModel<bool>> AddEdit(HannahModel model)
        {
            if (model.HannahId.Equals(Guid.Empty))
            {
                var entity = new Hannah()
                {
                    HannahId = Guid.NewGuid(),
                    BirthDay = null,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Name = model.Name,
                    IsDeleted = false,
                    UserId = model.UserId
                };
                //Add
                await HannahRepository.Add(entity);
            }
            else
            {
                var entity = await HannahRepository.Get(model.HannahId);
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Email = model.Email;
                    entity.PhoneNumber = model.PhoneNumber;
                    entity.UserId = model.UserId;

                    //Update
                    HannahRepository.Update(entity);
                }
                else
                {
                    return new ApiStatusModel<bool>()
                    {
                        ReturnData = false,
                        ApiStatusCode = ApiStatusCode.Empty,
                        ApiMessage = "Không tìm thấy Hannah."
                    };
                }
            }
            //Commit
            await UnitOfWork.CommitAsync();
            return new ApiStatusModel<bool>()
            {
                ReturnData = true,
                ApiStatusCode = ApiStatusCode.OK,
                ApiMessage = model.HannahId.Equals(Guid.Empty) ? "Thêm Hannah thành công." : "Chỉnh sửa Hannah thành công."
            };
        }
    }
}
