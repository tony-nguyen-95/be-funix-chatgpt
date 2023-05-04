using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Funix.HannahAssistant.Api.Repository
{
    public class StickyNoteRepository : IStickyNoteRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public StickyNoteRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<StickyNote>> Get(Guid StudentId, DateTime StartDate, DateTime EndDate)
        {
            var query = (from s in DbContext.StickyNotes
                         join hs in DbContext.HannahStudents on s.HannahStudentId equals hs.HannahStudentId
                         where hs.StudentId.Equals(StudentId)
                         && StartDate >= s.CreatedDate
                         && s.CreatedDate <= EndDate
                         && !s.IsDeleted
                         select s);
            return await query.ToListAsync();
        }

        public async Task<List<StickyNote>> Get(Guid StudentId, Guid HannahId, DateTime StartDate, DateTime EndDate)
        {
            var query = (from s in DbContext.StickyNotes
                         join hs in DbContext.HannahStudents on s.HannahStudentId equals hs.HannahStudentId
                         where hs.StudentId.Equals(StudentId) 
                         && hs.HannahId.Equals(HannahId) 
                         && StartDate >= s.CreatedDate 
                         && s.CreatedDate <= EndDate
                         && !s.IsDeleted
                         select s);
            return await query.ToListAsync();
        }

        public async Task<StickyNote?> GetById(Guid StickyNoteId)
        {
            return await DbContext.StickyNotes
                .Where(x => x.StickyNoteId.Equals(StickyNoteId)).FirstOrDefaultAsync();
        }

        public async Task<List<StickyNote>> GetById(List<Guid> Ids)
        {
            return await DbContext.StickyNotes.Where(x => Ids.Contains(x.StickyNoteId)).ToListAsync();
        }

        public async Task Add(StickyNote entity)
        {
            await DbContext.StickyNotes.AddAsync(entity);
        }

        public void Update(StickyNote entity)
        {
            DbContext.StickyNotes.Update(entity);
        }

        public void Update(List<StickyNote> entities)
        {
            DbContext.StickyNotes.UpdateRange(entities);
        }
    }
}
