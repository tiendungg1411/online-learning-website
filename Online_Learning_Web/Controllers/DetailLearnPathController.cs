using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Learning_Web.Models;

namespace Online_Learning_Web.Controllers
{
    public class DetailLearnPathController : Controller
    {
        private readonly MyDbContext _context;

        public DetailLearnPathController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var rt = _context.RouteTypes.FirstOrDefault(r => r.ID == id);
            ViewBag.rt=rt;
            var listC = _context.RouteTypeItems.Include(r => r.Courses).Where(r => r.RouteTypeID == id).ToList();
            ViewBag.listC =listC;
            return View();
        }
    }
}
