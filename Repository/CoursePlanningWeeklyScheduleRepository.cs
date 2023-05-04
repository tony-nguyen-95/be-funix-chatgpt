using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Funix.HannahAssistant.Api.Repository
{
    public class CoursePlanningWeeklyScheduleRepository : ICoursePlanningWeeklyScheduleRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public CoursePlanningWeeklyScheduleRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<CoursePlanningWeeklySchedule>> GetByStudentId(Guid StudentId)
        {
            var query = (from sc in DbContext.StudentCertificates
                         join co in DbContext.Courses on sc.CertificateId equals co.CertificateId
                         join cp in DbContext.CoursePlanningWeeklySchedules on co.CourseId equals cp.CourseId
                         where cp.EndDate <= DateTime.Now.Date
                         select cp);
            return await query.ToListAsync();
        }

        public async Task<CoursePlanningWeeklySchedule?> Get(Guid Id)
        {
            return await DbContext.CoursePlanningWeeklySchedules
                .Where(x => x.CoursePlanningWeeklyScheduleId.Equals(Id))
                .FirstOrDefaultAsync();
        }

        public async Task Add(CoursePlanningWeeklySchedule entity)
        {
            await DbContext.CoursePlanningWeeklySchedules.AddAsync(entity);
        }

        public async Task Add(List<CoursePlanningWeeklySchedule> entities)
        {
            await DbContext.CoursePlanningWeeklySchedules.AddRangeAsync(entities);
        }

        public void Update(CoursePlanningWeeklySchedule entity)
        {
            DbContext.CoursePlanningWeeklySchedules.Update(entity);
        }
    }
}
