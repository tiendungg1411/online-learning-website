using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Learning_Web.Models;

namespace Online_Learning_Web.Controllers
{
    public class CourseDetailController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly MyDbContext _context;
        public CourseDetailController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, MyDbContext context)
        {

            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Index(int ID, int lessonId)
        {
            // Get user
            AppUser user = new AppUser();
            user = _userManager.Users.FirstOrDefault(x => x.Id == _userManager.GetUserId(User));
            // Add to MyCourse of user
            Course course = new Course();
            course = _context.Courses.FirstOrDefault(c => c.Id == ID);

            
            var list = _userManager.Users.FirstOrDefault(x => x.Courses.Contains(course));
            if (list == null)
            {
                user.Courses = new List<Course> { course };
                _context.SaveChanges();
            }
            //else if (user.Courses.Contains(course))
            //{
            //    user.Courses = new List<Course> { course };
            //    _context.AppUsers.Add(user);
            //    _context.SaveChanges();
            //}

            // Select Lesson of chapter
            var lessons = _context.Lessons.ToList();
            if (lessonId != 0)
            {
                // Check type of lesson
                Lesson ls = _context.Lessons.FirstOrDefault(l => l.ID == lessonId);
                if (ls.Type.Equals("practice"))
                {
                    return Redirect("/Questions/DoingQuestion?lessonID=" + lessonId + "&courseID=" + ID);
                }
            }
            // Select chapter of course
            var chapters = _context.Chapters.ToList();
            var chapterOfCourse = from chapter in chapters
                                  where chapter.CourseID == ID
                                  select chapter;



            ViewBag.Chapters = chapterOfCourse;
            ViewBag.Lessons = lessons;
            if (lessonId == 0)
            {
                ViewBag.lessonId = 146;
            }
            else
            {
                ViewBag.lessonId = lessonId;
            }
            return View();
        }

    }

}
