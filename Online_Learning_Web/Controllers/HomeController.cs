using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Learning_Web.Models;

namespace Online_Learning_Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    MyDbContext _dbContext;
    public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, MyDbContext dbContext)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        //Get user info
        ViewBag.UserID = _userManager.GetUserId(User); // Lay user
        ViewBag.UserName = _userManager.GetUserName(User); // Lay user
        var courses = _dbContext.Courses.ToList();
        return View(courses);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Logout()
    {
        _signInManager.SignOutAsync();
        return View("Index");
    }
}
