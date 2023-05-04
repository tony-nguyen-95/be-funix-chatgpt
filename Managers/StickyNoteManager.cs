using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IManagers;
using Funix.HannahAssistant.Api.IRepository;
using Funix.HannahAssistant.Api.Models;

namespace Funix.HannahAssistant.Api.Managers
{
    public class StickyNoteManager : IStickyNoteManager
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private IHannahStudentRepository HannahStudentRepository { get; set; }
        private IStickyNoteRepository StickyNoteRepository { get; set; }
        public StickyNoteManager(IUnitOfWork unitOfWork, 
            IStickyNoteRepository stickyNoteRepository,
            IHannahStudentRepository hannahStudentRepository)
        {
            UnitOfWork = unitOfWork;
            StickyNoteRepository = stickyNoteRepository;
            HannahStudentRepository = hannahStudentRepository;
        }

        public async Task<ApiStatusModel<List<StickyNote>>> Get(Guid StudentId, Guid HannahId, DateTime StartDate, DateTime EndDate)
        {
            var stickyNotes = new List<StickyNote>();
            if (HannahId.Equals(Guid.Empty))
                stickyNotes = await StickyNoteRepository.Get(StudentId, StartDate, EndDate);
            else
                stickyNotes = await StickyNoteRepository.Get(StudentId, HannahId, StartDate, EndDate);
            return new ApiStatusModel<List<StickyNote>>() { 
                ReturnData = stickyNotes.Count > 0 ? stickyNotes : null,
                ApiStatusCode = stickyNotes.Count > 0 ? ApiStatusCode.OK : ApiStatusCode.Empty,
                ApiMessage = stickyNotes.Count > 0 ? "Đã tìm thấy các sticky note." : "Không tìm thấy sticky note."
            };

        }

        public async Task<ApiStatusModel<bool>> Delete(List<Guid> Ids)
        {
            var stickyNotes = await StickyNoteRepository.GetById(Ids);
            if (stickyNotes != null && stickyNotes.Count > 0)
            {
                stickyNotes.ForEach(x => x.IsDeleted = true);
                //Update
                StickyNoteRepository.Update(stickyNotes);
                //Commit
                await UnitOfWork.CommitAsync();
            }
            return new ApiStatusModel<bool>() { 
                ReturnData = stickyNotes != null && stickyNotes.Count > 0,
                ApiStatusCode = stickyNotes != null && stickyNotes.Count > 0 ? ApiStatusCode.OK : ApiStatusCode.Empty,
                ApiMessage = stickyNotes != null && stickyNotes.Count > 0 ? "Xóa sticky notes thành công" : "Xóa sticky notes thất bại. Vui lòng thử lại sau."
            };
        }

        /// <summary>
        /// Nếu là Hannah đang hỗ trợ học viên thì cho phép thêm và điều chỉnh sticky note.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiStatusModel<bool>> AddEdit(StickyNoteModel model)
        {
            var hStudent = await HannahStudentRepository.GetById(model.HannahStudentId);
            if (hStudent != null && hStudent.IsSupport)
            {
                if (model.StickyNoteId.Equals(Guid.Empty))
                {
                    var sNote = new StickyNote()
                    {
                        StickyNoteId = Guid.NewGuid(),
                        HannahStudentId = model.HannahStudentId,
                        StudentContactId = model.StudentContactId,
                        Content = model.Content,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        IsDeleted = false
                    };
                    //Add
                    await StickyNoteRepository.Add(sNote);
                }
                else
                {
                    var sNote = await StickyNoteRepository.GetById(model.StickyNoteId);
                    if (sNote != null)
                    {
                        sNote.StudentContactId = model.StudentContactId;
                        sNote.Content = model.Content;
                        sNote.UpdatedDate = DateTime.UtcNow;
                        //Update
                        StickyNoteRepository.Update(sNote);
                    }
                    else
                        return new ApiStatusModel<bool>() { ReturnData = false, ApiStatusCode = ApiStatusCode.Empty, ApiMessage = "Không tìm thấy sticky note." };
                }
                //Commit
                await UnitOfWork.CommitAsync();
                return new ApiStatusModel<bool>() { ReturnData = true, ApiStatusCode = ApiStatusCode.OK, ApiMessage = model.StickyNoteId.Equals(Guid.Empty) ? "Thêm mới tương tác cho học viên thành công." : "Cập nhật tương tác cho học viên không thành công." };
            }
            return new ApiStatusModel<bool>() { ReturnData = false, ApiStatusCode = ApiStatusCode.Empty, ApiMessage = "Không thêm mới/chỉnh sửa các StickyNote. Do đã quá thời hạn hỗ trợ học viên." };
        }
    }
}
