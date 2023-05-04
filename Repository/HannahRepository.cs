using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Funix.HannahAssistant.Api.Repository
{
    public class HannahRepository : IHannahRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public HannahRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<Guid>> GetUserId()
        {
            return await DbContext.Hannahs
                .Where(x => x.UserId.HasValue)
                .Select(x => x.UserId.Value).ToListAsync();
        }

        public async Task<Hannah?> Get(string UserName)
        {
            return await DbContext.Hannahs
                .Where(x => x.Name.Equals(UserName) && !x.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Hannah>> Get()
        {
            return await DbContext.Hannahs
                .Include(x => x.Students)
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }


        public async Task<Hannah?> Get(Guid UserId)
        {
            return await DbContext.Hannahs
                .Where(x => x.HannahId.Equals(UserId))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Hannah>> Get(List<Guid> Ids)
        {
            return await DbContext.Hannahs
                .Where(x => Ids.Contains(x.HannahId))
                .ToListAsync();
        }

        public async Task Add(Hannah entity)
        {
            DbContext.Hannahs.Add(entity);
        }

        public void Update(Hannah entity)
        {
            DbContext.Hannahs.Update(entity);
        }

        public void Update(List<Hannah> entities)
        {
            DbContext.Hannahs.UpdateRange(entities);
        }
    }
}
