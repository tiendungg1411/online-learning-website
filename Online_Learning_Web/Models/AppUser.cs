using Microsoft.AspNetCore.Identity;

namespace Online_Learning_Web.Models
{
    public class AppUser : IdentityUser
    {
        public List<Course> Courses {  get; set; }
        public List<Question> Questions { get; set; }

    }
}
