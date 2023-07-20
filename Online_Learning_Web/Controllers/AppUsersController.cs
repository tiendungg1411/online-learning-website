using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Learning_Web.Models;

namespace Online_Learning_Web.Controllers
{
    public class AppUsersController : Controller
    {
        public class UserAndRole : AppUser
        {
            public string RoleNames { get; set; }
        }
        private readonly UserManager<AppUser> _userManager;
        public AppUsersController(UserManager<AppUser> userManager) 
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            
            var qr = from u in _userManager.Users
                               select new UserAndRole
                               {
                                   Id = u.Id,
                                   UserName = u.UserName,
                               };
            var listAppUsers = qr.ToList();
            foreach (var user in listAppUsers)
            {
                var roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(user.Id));
                user.RoleNames = string.Join(", ", roles);
            }
            ViewBag.listAppUsers = listAppUsers;
            return View();
        }
    }
}
