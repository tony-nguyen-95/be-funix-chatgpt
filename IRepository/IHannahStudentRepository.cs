using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface IHannahStudentRepository
    {
        Task<HannahStudent?> GetById(Guid HannahStudentId);
        Task<List<HannahStudent>> GetStudentSupport(List<Guid> StudentIds);
        Task<List<HannahStudent>> GetStudentNotSupport(List<Guid> StudentIds);
        Task<HannahStudent?> Get(Guid HannahId, Guid StudentId);
        Task<List<HannahStudent>> Get(Guid HannahId, DateTime StartDate, DateTime EndDate, int Status, bool IsSupport);
        Task<List<HannahStudent>> Get(Guid HannahId);
        Task Add(HannahStudent entity);
        Task Add(List<HannahStudent> entities);
        void Update(HannahStudent entity);
        void Update(List<HannahStudent> entities);
    }
}
