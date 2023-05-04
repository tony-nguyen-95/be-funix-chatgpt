using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.Models;

namespace Funix.HannahAssistant.Api.IManagers
{
    public interface IStickyNoteManager
    {
        Task<ApiStatusModel<List<StickyNote>>> Get(Guid StudentId, Guid HannahId, DateTime StartDate, DateTime EndDate);
        Task<ApiStatusModel<bool>> AddEdit(StickyNoteModel model);
        Task<ApiStatusModel<bool>> Delete(List<Guid> Ids);
    }
}
