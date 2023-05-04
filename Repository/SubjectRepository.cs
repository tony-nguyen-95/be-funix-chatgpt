using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Funix.HannahAssistant.Api.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public SubjectRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<Subject>> GetByCourseId(Guid CourseId)
        {
            return await DbContext
                .Subjects
                .Where(x => x.CourseId.Equals(CourseId)).ToListAsync();
        }

        public async Task Add(Subject entity)
        {
            await DbContext.Subjects.AddAsync(entity);
        }

        public async Task Add(List<Subject> entities)
        {
            await DbContext.Subjects.AddRangeAsync(entities);
        }
    }
}
