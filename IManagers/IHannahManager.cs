using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.Models;

namespace Funix.HannahAssistant.Api.IManagers
{
    public interface IHannahManager
    {
        Task<ApiStatusModel<List<HannahItem>>> GetHannahs();
        Task<ApiStatusModel<Hannah>> GetById(Guid HannahId);
        Task<ApiStatusModel<bool>> Delete(List<Guid> Ids);
        Task<ApiStatusModel<bool>> AddEdit(HannahModel model);
        Task<ApiStatusModel<bool>> AddStudent(Guid HannahId, List<Guid> StudentIds, DateTime StartDate);
    }
}
