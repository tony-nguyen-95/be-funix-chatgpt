using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Funix.HannahAssistant.Api.Repository
{
    public class StudentContactRepository : IStudentContactRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public StudentContactRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<StudentContact?> Get(Guid StudentContactId)
        {
            return await DbContext.StudentContacts.Where(x => x.StudentId.Equals(StudentContactId)).FirstOrDefaultAsync();
        }

        public async Task<List<StudentContact>> GetByStudentId(Guid StudentId)
        {
            return await DbContext.StudentContacts.Where(x => x.StudentId.Equals(StudentId)).ToListAsync();
        }

        public async Task<List<StudentContact>> Get(List<Guid> Ids)
        {
            return await DbContext.StudentContacts.Where(x => Ids.Contains(x.StudentContactId) && !x.IsDeleted).ToListAsync();
        }

        public async Task Add(StudentContact entity)
        {
            await DbContext.StudentContacts.AddAsync(entity);
        }

        public void Update(StudentContact entity)
        {
            DbContext.StudentContacts.Update(entity);
        }

        public void Update(List<StudentContact> entities)
        {
            DbContext.StudentContacts.UpdateRange(entities);
        }
    }
}
