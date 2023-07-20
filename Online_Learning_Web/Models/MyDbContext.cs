using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Online_Learning_Web.Models
{
    public class MyDbContext : IdentityDbContext<AppUser>
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CourseRouteTypeItem>().HasKey(c => new { c.CId, c.RIId });
        //}



        public List<AppUser> AppUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseLearnWhat> CourseLearnWhats { get; set; }
        public DbSet<CourseRequirement> CourseRequirements { get; set; }
        public DbSet<RouteType> RouteTypes { get; set; }
        public DbSet<RouteTypeItem> RouteTypeItems { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<CorrectAnswer> CorrectAnswers { get; set; }
        public DbSet<AppUserQuestions> AppUserQuestions { get; set; }
        //public DbSet<CourseRouteTypeItem> CourseRouteTypesItems { get; set; }
    }
}
