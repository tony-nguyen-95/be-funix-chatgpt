using Funix.HannahAssistant.Api.IRepository;

namespace Funix.HannahAssistant.Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public UnitOfWork(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
