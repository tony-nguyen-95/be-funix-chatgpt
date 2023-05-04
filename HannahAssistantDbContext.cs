using Funix.HannahAssistant.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Funix.HannahAssistant.Api.Common;

namespace Funix.HannahAssistant.Api
{
    public class HannahAssistantDbContext : DbContext
    {
        public HannahAssistantDbContext(DbContextOptions<HannahAssistantDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                UserId = Guid.NewGuid(),
                UserName = "dattlt",
                Password = "P@ssw0rd".ToSHA512HashString(),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                FunixId = "",
                FunixEmail = "",
                Hannah = null,
                IsDeleted = false,
                LoginDate = DateTime.UtcNow,
            }, new User() {
                UserId = Guid.NewGuid(),
                UserName = "huynq",
                Password = "P@ssw0rd".ToSHA512HashString(),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                FunixId = "",
                FunixEmail = "",
                Hannah = null,
                IsDeleted = false,
                LoginDate = DateTime.UtcNow,
            }, new User() {
                UserId = Guid.NewGuid(),
                UserName = "dungtct",
                Password = "P@ssw0rd".ToSHA512HashString(),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                FunixId = "",
                FunixEmail = "",
                Hannah = null,
                IsDeleted = false,
                LoginDate = DateTime.UtcNow,
            });
        }

        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CoursePlanningWeeklySchedule> CoursePlanningWeeklySchedules { get; set; }
        public DbSet<Hannah> Hannahs { get; set; }
        public DbSet<Lession> Lessions { get; set; }
        public DbSet<StickyNote> StickyNotes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCertificate> StudentCertificates { get; set; }
        public DbSet<StudentContact> StudentContacts { get; set; }
        public DbSet<HannahStudent> HannahStudents { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        //Temp
        public DbSet<TempCertificate> TempCertificates { get; set; }
        public DbSet<TempCertificateCourse> TempCertificateCourses { get; set; }
        public DbSet<TempCourse> TempCourses { get; set; }
        public DbSet<TempSubject> TempSubjects { get; set; }
        public DbSet<TempLession> TempLessions { get; set; }
        public DbSet<TempCourseWeeklySchedule> TempCourseWeeklySchedules { get; set; }
    }
}
