using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Funix.HannahAssistant.Api.Repository
{
    public class TempSubjectRepository : ITempSubjectRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public TempSubjectRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<TempSubject>> Get()
        {
            return await DbContext.TempSubjects
                .Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<List<TempSubject>> GetByCourseId(Guid TempCourseId)
        {
            return await DbContext.TempSubjects
                .Where(x => x.TempCourseId.Equals(TempCourseId)).ToListAsync();
        }

        public async Task Add(TempSubject entity)
        {
            await DbContext.TempSubjects.AddAsync(entity);
        }

        public async Task Add(List<TempSubject> entities)
        {
            await DbContext.TempSubjects.AddRangeAsync(entities);
        }

        public void Update(TempSubject entity)
        {
            DbContext.TempSubjects.Update(entity);
        }

        public void Update(List<TempSubject> entities)
        {
            DbContext.TempSubjects.UpdateRange(entities);
        }
    }
}
