using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Packaging;
using Online_Learning_Web.Models;
using System.Collections;
using System.Collections.Generic;

namespace Online_Learning_Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RouteCourseItemController : Controller
    {
        private readonly MyDbContext _context;

        public RouteCourseItemController(MyDbContext context)
        {
            _context = context;
        }
        // Get: RouteCourseItem
        public async Task<IActionResult> Index()
        {
            //var ListRouteCourseItem = _context.RouteTypeItems.Include(c => c.Courses).Include(c => c.RouteType).ToList();
            var ListRouteCourseItem = _context.RouteTypeItems.Include(c => c.RouteType).ToList();
            return View(ListRouteCourseItem);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var rt = _context.RouteTypeItems.Include(c => c.Courses).FirstOrDefault(x => x.ID == id);
            if (rt != null)
            {
                _context.RemoveRange(rt);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            var routeTypeItem = _context.RouteTypeItems.FirstOrDefault(r => r.ID == id);
            var routeCourseItem = _context.RouteTypeItems.Include(r => r.Courses).Include(r => r.RouteType).Where(r => r.ID == id).ToList();
            ViewBag.routeCourseItem = routeCourseItem;
            ViewBag.routeTypeItem = routeTypeItem;
            return View();
        }

        // GET: RouteTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var listRouteType = _context.RouteTypes.ToList();
            var listCourse = _context.Courses.Where(c => c.IsPublished == true).ToList();
            ViewBag.RouteType = listRouteType;
            ViewBag.ListCourse = listCourse;

            var routeTypeItem = _context.RouteTypeItems.FirstOrDefault(r => r.ID == id);
            var routeCourseItem = _context.RouteTypeItems.Include(r => r.Courses).Include(r => r.RouteType).Where(r => r.ID == id).ToList();
            ViewBag.rc = routeCourseItem;
            ViewBag.routeTypeItem = routeTypeItem;

            return View(routeTypeItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RouteTypeItem routeTypeItem, int[] idCourses)
        {
            List<Course> listC = new List<Course>();
            foreach (var coursesId in idCourses)
            {
                Course c = _context.Courses.FirstOrDefault(d => d.Id == coursesId);
                listC.Add(c);
            }
            _context.RouteTypeItems.Update(routeTypeItem);
            var routeCourseItem = _context.RouteTypeItems.Include(r => r.Courses).Where(r => r.ID == routeTypeItem.ID).ToList();
            List<Course> listCO = new List<Course>();
            foreach (var r in routeCourseItem)
            {
                foreach (var c in r.Courses)
                {
                    _context.RouteTypeItems.Include(r => r.Courses).FirstOrDefault(r => r.ID == routeTypeItem.ID).Courses.Remove(c);
                }
            }
            _context.RouteTypeItems.Include(r => r.Courses).FirstOrDefault(r => r.ID == routeTypeItem.ID).Courses.AddRange(listC);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: RouteTypes/Create
        public IActionResult Create()
        {
            var listRouteType = _context.RouteTypes.ToList();
            var listCourse = _context.Courses.Where(c => c.IsPublished == true).ToList();
            ViewBag.RouteType = listRouteType;
            ViewBag.ListCourse = listCourse;
            return View();
        }

        // POST: RouteTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RouteTypeItem routeTypeItem, int[] idCourses)
        {
            List<Course> listC = new List<Course>();
            foreach (var coursesId in idCourses)
            {
                Course c = _context.Courses.FirstOrDefault(d => d.Id == coursesId);
                listC.Add(c);
            }
            RouteTypeItem r = new RouteTypeItem()
            {
                Name = routeTypeItem.Name,
                Description = routeTypeItem.Description,
                RouteTypeID = routeTypeItem.RouteTypeID,
            };
            r.Courses = new List<Course>();
            _context.RouteTypeItems.Add(r);
            _context.SaveChanges();

            r.Courses.AddRange(listC);
            _context.RouteTypeItems.Update(r);
            _context.SaveChanges();



            return RedirectToAction(nameof(Index));
            //}


            var listRouteType = _context.RouteTypes.ToList();
            var listCourse = _context.Courses.Where(c => c.IsPublished == true).ToList();
            ViewBag.RouteType = listRouteType;
            ViewBag.ListCourse = listCourse;
            return View(routeTypeItem);

        }
    }
}
