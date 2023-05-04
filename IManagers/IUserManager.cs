using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.Models;

namespace Funix.HannahAssistant.Api.IManagers
{
    public interface IUserManager
    {
        Task<ApiStatusModel<AuthModel>> Auth(string UserName, string Password);
        Task<ApiStatusModel<List<User>>> GetAll();
        Task<ApiStatusModel<bool>> AddEdit(UserModel user);
        Task<ApiStatusModel<User>> GetById(Guid UserId);
        Task<ApiStatusModel<bool>> Delete(List<Guid> Ids);
        Task<ApiStatusModel<List<User>>> GetUserNotAssign();
    }
}
