using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface IUserRepository
    {
        Task<User?> Auth(string UserName, string Password);
        Task<User?> Get(string UserName);
        Task<User?> Get(Guid UserId);
        Task Add(User entity);
        void Update(User entity);
        void Update(List<User> entities);
        Task<List<User>> GetAll();
        Task<List<User>> Get(List<Guid> Ids);
        Task<List<User>> GetUserNotAssign(List<Guid> UserIds);
    }
}
