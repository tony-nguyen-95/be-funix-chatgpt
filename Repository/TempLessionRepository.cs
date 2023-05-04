using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Funix.HannahAssistant.Api.Repository
{
    public class TempLessionRepository : ITempLessionRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public TempLessionRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<TempLession>> GetByCourseId(Guid TempCourseId)
        {
            var query = (from c in DbContext.TempCourses
                        join s in DbContext.TempSubjects on c.TempCourseId equals s.TempCourseId
                        join l in DbContext.TempLessions on s.TempSubjectId equals l.TempSubjectId
                        where c.TempCourseId.Equals(TempCourseId) && !c.IsDeleted && !s.IsDeleted && !l.IsDeleted
                        select l);
            return await query.ToListAsync();
        }

        public async Task<List<TempLession>> GetBySubjectId(Guid TempSubjectId)
        {
            return await DbContext.TempLessions.Where(x => x.TempSubjectId.Equals(TempSubjectId)).ToListAsync();
        }

        public async Task Add(TempLession entity)
        {
            await DbContext.TempLessions.AddAsync(entity);
        }

        public async Task Add(List<TempLession> entities)
        {
            await DbContext.TempLessions.AddRangeAsync(entities);
        }

        public void Update(TempLession entity)
        {
            DbContext.TempLessions.Update(entity);
        }

        public void Update(List<TempLession> entities)
        {
            DbContext.TempLessions.UpdateRange(entities);
        }
    }
}
