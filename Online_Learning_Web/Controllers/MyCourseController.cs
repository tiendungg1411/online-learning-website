using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Learning_Web.Models;
using System.Linq;

namespace Online_Learning_Web.Controllers
{
    public class MyCourseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly MyDbContext _context;

        public MyCourseController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, MyDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Index(string txtSearch)
        {
            // Load course list
            var course = _context.Courses.ToList();
            List<Course> listCourse = new List<Course>();
            foreach (var courseItem in course)
            {
                var list = _userManager.Users.FirstOrDefault(x => x.Id == _userManager.GetUserId(User) && x.Courses.Contains(courseItem));
                if(list != null)
                {
                    listCourse.Add(courseItem);
                }
            }
            // Search by txtSearch
            if (!string.IsNullOrWhiteSpace(txtSearch))
            {
                List<Course> listSearch = new List<Course>();
                foreach (var courseItem in listCourse)
                {
                    courseItem.Title.ToUpper();
                    if (courseItem.Title.Contains(txtSearch.ToUpper()))
                    {
                        listSearch.Add(courseItem);
                    }
                }
                ViewBag.txtSearch = txtSearch;
                if(txtSearch!= null)
                {
                ViewBag.notFound = "not found";
                }

                return View(listSearch);
            }
            

            return View(listCourse);
        }
    }
}
