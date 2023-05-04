using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.Models;

namespace Funix.HannahAssistant.Api.IManagers
{
    public interface IStudentManager
    {
        Task<ApiStatusModel<List<Student>>> GetStudentNotSupport();
        Task<ApiStatusModel<List<StudentItem>>> GetStudents();
        Task<ApiStatusModel<Student>> GetById(Guid StudentId);
        Task<ApiStatusModel<bool>> Delete(List<Guid> Ids);
        Task<ApiStatusModel<bool>> AddEdit(StudentModel model);
        Task<ApiStatusModel<bool>> AddEditContact(StudentContactModel model);
        Task<ApiStatusModel<List<StudentContact>>> GetContactByStudentId(Guid StudentId);
        Task<ApiStatusModel<bool>> DeleteContact(List<Guid> ContactIds);
        Task<ApiStatusModel<bool>> ChangeHannah(Guid StudentId, Guid CurrentHannahdId, Guid HannahId, DateTime StartDate);
        Task<ApiStatusModel<List<ListHannahStudentModel>>> GetStudentByHannah(Guid HannahId, DateTime StartDate, DateTime EndDate, int Status, bool IsSupport);
        Task<ApiStatusModel<bool>> AddStudentCertificate(Guid StudentId, Guid TempCertificateId, DateTime StartDate);
        Task<ApiStatusModel<bool>> AddLessionProgress(Guid LessionId, bool IsDone);
    }
}
