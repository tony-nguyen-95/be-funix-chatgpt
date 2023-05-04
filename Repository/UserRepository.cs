using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Funix.HannahAssistant.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public UserRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<User?> Auth(string UserName, string Password)
        {
            return await DbContext.Users
                .Where(x => x.UserName.ToLower().Equals(UserName.ToLower()) && x.Password.ToLower().Equals(Password.ToLower()))
                .FirstOrDefaultAsync();
        }

        public async Task<User?> Get(string UserName)
        {
            return await DbContext.Users
                .Include(x => x.Hannah)
                .Where(x => x.UserName.ToLower().Equals(UserName.ToLower()) && !x.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await DbContext.Users
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }


        public async Task<User?> Get(Guid UserId)
        {
            return await DbContext.Users
                .Where(x => x.UserId.Equals(UserId))
                .FirstOrDefaultAsync();
        }

        public async Task<List<User>> Get(List<Guid> Ids)
        {
            return await DbContext.Users
                .Where(x => Ids.Contains(x.UserId))
                .ToListAsync();
        }

        public async Task<List<User>> GetUserNotAssign(List<Guid> UserIds)
        {
            return await DbContext.Users
                .Where(x => !UserIds.Contains(x.UserId))
                .ToListAsync();
        }

        public async Task Add(User entity)
        {
            DbContext.Users.Add(entity);
        }

        public void Update(User entity) 
        {
            DbContext.Users.Update(entity);
        }

        public void Update(List<User> entities)
        {
            DbContext.Users.UpdateRange(entities);
        }
    }
}
