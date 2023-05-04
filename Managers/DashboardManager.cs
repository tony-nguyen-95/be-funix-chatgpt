using Funix.HannahAssistant.Api.IManagers;
using Funix.HannahAssistant.Api.Models;

namespace Funix.HannahAssistant.Api.Managers
{
    public class DashboardManager : IDashboardManager
    {
        public async Task<ApiStatusModel<DashboardModel>> Get(Guid HannahId)
        {
            return new ApiStatusModel<DashboardModel>()
            {
                ReturnData = new DashboardModel() { 
                    TotalStudent = 100,
                    TotalDoneStudent = 50,
                    TotalLearningStudent = 50,
                    TotalOnScheduleStudent = 30,
                    TotalDelayProgressStudent = 10,
                    TotalOverProgressStudent = 10,
                    TotalStickyNotePerWeek = 100,
                    TotalStickyNotePerMonth = 1000,
                    TotalStickyNotePerYear = 3000
                },
                ApiStatusCode = ApiStatusCode.OK,
                ApiMessage = "Lấy dữ liệu thành công."
            };
        }
    }
}
