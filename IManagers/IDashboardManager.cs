using Funix.HannahAssistant.Api.Models;

namespace Funix.HannahAssistant.Api.IManagers
{
    public interface IDashboardManager
    {
        Task<ApiStatusModel<DashboardModel>> Get(Guid HannahId);
    }
}
