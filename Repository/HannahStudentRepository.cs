using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Funix.HannahAssistant.Api.Repository
{
    public class HannahStudentRepository : IHannahStudentRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public HannahStudentRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<HannahStudent?> GetById(Guid HannahStudentId)
        {
            return await DbContext
                .HannahStudents
                .Where(x => x.HannahStudentId.Equals(HannahStudentId)).FirstOrDefaultAsync();
        }

        public async Task<HannahStudent?> Get(Guid HannahId, Guid StudentId)
        {
            return await DbContext.HannahStudents
                .Where(x => x.HannahId.Equals(HannahId) && x.StudentId.Equals(StudentId))
                .FirstOrDefaultAsync();
        }

        public async Task<List<HannahStudent>> Get(Guid HannahId)
        {
            return await DbContext.HannahStudents
                .Where(x => x.HannahId.Equals(HannahId))
                .ToListAsync();
        }

        public async Task<List<HannahStudent>> Get(Guid HannahId, DateTime StartDate, DateTime EndDate, int Status, bool IsSupport)
        {
            Expression<Func<HannahStudent, bool>> statusCond = x => 1 == 1;
            if (!Status.Equals(0))
                statusCond = x => x.Student != null && x.Student.Status.Equals(Status);

            return await DbContext.HannahStudents
                .Include(x => x.Student)
                .Where(x => x.HannahId.Equals(HannahId)
                && x.IsSupport.Equals(IsSupport)
                && StartDate >= x.StartDate
                && EndDate >= x.EndDate).Where(statusCond).ToListAsync();
        }

        public async Task<List<HannahStudent>> GetStudentNotSupport(List<Guid> StudentIds)
        {
            return await DbContext.HannahStudents
                .Include(x => x.Student)
                .Where(x => !StudentIds.Contains(x.StudentId) && !x.IsSupport).ToListAsync();
        }

        public async Task<List<HannahStudent>> GetStudentSupport(List<Guid> StudentIds)
        {
            return await DbContext.HannahStudents
                .Where(x => StudentIds.Contains(x.StudentId) && x.IsSupport)
                .ToListAsync();
        }

        public async Task Add(HannahStudent entity)
        {
            await DbContext.HannahStudents.AddAsync(entity);
        }

        public async Task Add(List<HannahStudent> entities)
        {
            await DbContext.HannahStudents.AddRangeAsync(entities);
        }

        public void Update(HannahStudent entity)
        {
            DbContext.HannahStudents.Update(entity);
        }

        public void Update(List<HannahStudent> entities)
        {
            DbContext.HannahStudents.UpdateRange(entities);
        }
    }
}
