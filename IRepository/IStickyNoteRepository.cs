using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface IStickyNoteRepository
    {
        Task<List<StickyNote>> Get(Guid StudentId, Guid HannahId, DateTime StartDate, DateTime EndDate);
        Task<List<StickyNote>> Get(Guid StudentId, DateTime StartDate, DateTime EndDate);
        Task<StickyNote?> GetById(Guid StickyNoteId);
        Task<List<StickyNote>> GetById(List<Guid> Ids);
        Task Add(StickyNote entity);
        void Update(StickyNote entity);
        void Update(List<StickyNote> entities);
    }
}
