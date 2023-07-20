using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Learning_Web.Models;
using Online_Learning_Web.ViewModel;

namespace Online_Learning_Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var listRoles = _roleManager.Roles.ToList();

            ViewBag.listRoles = listRoles;
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = roleVM.Name,
                };
                await _roleManager.CreateAsync(role);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole roleDelete = await _roleManager.FindByIdAsync(id);

            if (!string.IsNullOrEmpty(id) && roleDelete != null)
            {
                await _roleManager.DeleteAsync(roleDelete);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole roleDelete = await _roleManager.FindByIdAsync(id);
            RoleVM roleVM = new RoleVM()
            {
                Name = roleDelete.Name,
            };
            ViewBag.role = roleDelete;
            return View(roleVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleVM roleVM, string id)
        {
            IdentityRole roleUpdate = await _roleManager.FindByIdAsync(id);
            roleUpdate.Name = roleVM.Name;
            await _roleManager.UpdateAsync(roleUpdate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddRole(string? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "AppUsers");
            }
            var listRoles = _roleManager.Roles.ToList();
            var listUserRoles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(id));
            var User = await _userManager.FindByIdAsync(id);
            ViewBag.listRoles = listRoles;
            ViewBag.listUserRoles = listUserRoles;
            ViewBag.User = User;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(string? id, string[] roles)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "AppUsers");
            }
            var listUserRoles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(id));
            var User = await _userManager.FindByIdAsync(id);

            if (listUserRoles != null)
            {
                //Add Roles
                foreach (var role in roles)
                {
                    if (!listUserRoles.Contains(role + ""))
                    {
                        await _userManager.AddToRoleAsync(User, role);
                    }
                }
                //Remove Roles
                foreach (var role in listUserRoles)
                {
                    if (!roles.Contains(role + ""))
                    {
                        await _userManager.RemoveFromRoleAsync(User, role);
                    }
                }
            }
            else
            {
                await _userManager.AddToRolesAsync(User, roles);
            }


            return RedirectToAction("Index", "AppUsers");
        }
    }
}
