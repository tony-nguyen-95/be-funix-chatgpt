using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Funix.HannahAssistant.Api.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public StudentRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<Student>> Get()
        {
            return await DbContext
                .Students
                .Include(x => x.Hannahs)
                .Where(x => !x.IsDeleted)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Student?> Get(Guid StudentId)
        {
            return await DbContext.Students.Where(x => x.StudentId.Equals(StudentId)).FirstOrDefaultAsync();
        }

        public async Task<List<Student>> Get(List<Guid> Ids)
        {
            return await DbContext.Students.Where(x => Ids.Contains(x.StudentId)).ToListAsync();
        }

        public async Task Add(Student entity)
        {
            await DbContext.Students.AddAsync(entity);
        }

        public void Update(Student entity)
        {
            DbContext.Students.Update(entity);
        }

        public void Update(List<Student> entities)
        {
            DbContext.Students.UpdateRange(entities);
        }
    }
}
