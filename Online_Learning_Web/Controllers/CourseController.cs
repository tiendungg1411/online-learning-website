using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Learning_Web.Models;
using Online_Learning_Web.ViewModel;

namespace Online_Learning_Web.Controllers
{
	[Authorize(Roles = "Admin")]
	public class CourseController : Controller
	{
		private readonly MyDbContext _context;
		public CourseController(MyDbContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			ViewBag.listCourse = _context.Courses.ToList();

			return View();
		}
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Courses == null)
			{
				return NotFound();
			}

			var course = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);
			if (course == null)
			{
				return NotFound();
			}
			ViewBag.listChapter = _context.Chapters.Where(c => c.CourseID == id).ToList();
			List<int> listChapId = _context.Chapters.Where(c => c.CourseID == id).Select(c => c.ID).ToList();
            List<Lesson> allLessons = new List<Lesson>();

            for (int i = 0; i < listChapId.Count; i++)
            {
                var lessonsInChapter = _context.Lessons.Where(c => c.ChapterID == listChapId[i]).ToList();
                allLessons.AddRange(lessonsInChapter);
            }

            ViewBag.ListLesson = allLessons;
			List<CourseLearnWhat> listL = _context.CourseLearnWhats.Where(t => t.CourseID == id).ToList();
			List<string> content = listL.Select(t => t.Content).ToList();
			string concatenatedContent = string.Join("\n", content);
			ViewBag.targetStr = concatenatedContent;

			List<CourseRequirement> listR = _context.CourseRequirements.Where(t => t.CourseID == id).ToList();
			List<string> content1 = listR.Select(t => t.Content).ToList();
			string concatenatedContent1 = string.Join("\n", content1);
			ViewBag.RequirementStr = concatenatedContent1;


			return View(course);
		}
		public IActionResult Create()
		{
			//ViewData["LessonID"] = new SelectList(_context.Lessons, "ID", "ID");

			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Course course)
		{
			Course course1 = new Course
			{
				Title = course.Title,
				Price = course.Price,
				IsPublished = course.IsPublished,
				Level = course.Level,
				Description = course.Description,
				Image = course.Image,
			};
			_context.Add(course1);
			_context.SaveChanges();

			ViewBag.listCourse = _context.Courses.ToList();
			return View("Index");
		}


		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Courses == null)
			{
				return NotFound();
			}

			var cour = await _context.Courses
				.FirstOrDefaultAsync(m => m.Id == id);

			if (cour == null)
			{
				return NotFound();
			}

			return View(cour);
		}

		// POST: Questions/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Courses == null)
			{
				return Problem("Entity set 'MyDbContext.Courses'  is null.");
			}
			var cour = await _context.Courses.FindAsync(id);
			if (cour != null)
			{
				_context.Courses.Remove(cour);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		//Get:
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Courses == null)
			{
				return NotFound();
			}
			var course = from c in _context.Courses
						 where c.Id == id
						 select new Course
						 {
							 Title = c.Title,
							 Price = c.Price,
							 IsPublished = c.IsPublished,
							 Level = c.Level,
							 Description = c.Description,
							 Image = c.Image,
						 };
			

			ViewBag.listChapter = _context.Chapters.Where(c => c.CourseID == id).ToList();

			List<CourseLearnWhat> listL = _context.CourseLearnWhats.Where(t => t.CourseID == id).ToList();
			List<string> content = listL.Select(t => t.Content).ToList();
			string concatenatedContent = string.Join("\n", content);
			ViewBag.targetStr = concatenatedContent;

			List<CourseRequirement> listR = _context.CourseRequirements.Where(t => t.CourseID == id).ToList();
			List<string> content1 = listR.Select(t => t.Content).ToList();
			string concatenatedContent1 = string.Join("\n", content1);
			ViewBag.RequirementStr = concatenatedContent1;

			List<Chapter> listC = _context.Chapters.Where(c => c.CourseID == id).ToList();
			ViewBag.listChapter = listC;

			return View(course.FirstOrDefault());
		}

		// POST: Questions/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Course cour, int id, string target, string requirement, string[] chapter)
		{
			Course course1 = new Course
			{
				Id = id,
				Title = cour.Title,
				Price = cour.Price,
				IsPublished = cour.IsPublished,
				Level = cour.Level,
				Description = cour.Description,
				Image = cour.Image,
			};
			_context.Update(course1);
			_context.SaveChanges();
			_context.CourseLearnWhats.RemoveRange(_context.CourseLearnWhats.ToList());
			_context.SaveChanges();
			_context.CourseRequirements.RemoveRange(_context.CourseRequirements.ToList());
			_context.SaveChanges();
			if (!string.IsNullOrWhiteSpace(target))
			{
				string[] targetS = target.Split("\n");
				foreach (string s in targetS)
				{
					CourseLearnWhat clw = new CourseLearnWhat
					{
						Content = s,
						CourseID = id,
					};
					_context.Add(clw);
					_context.SaveChanges();

				}
			}

			if (!string.IsNullOrWhiteSpace(requirement))
			{
				string[] requiS = requirement.Split("\n");
				foreach (string s in requiS)
				{
					CourseRequirement cr = new CourseRequirement
					{
						Content = s,
						CourseID = id,
					};
					_context.Add(cr);
					_context.SaveChanges();
				}
			}
			List<string> listC = _context.Chapters.Where(c => c.CourseID == id).Select(c => c.Name).ToList();
			if (chapter != null)
			{
				List<Chapter> newChapters = new List<Chapter>();
				foreach (string s in chapter)
				{

					if (listC.Contains(s))
					{
					}
					else
					{
						Chapter chapter1 = new Chapter
						{
							Name = s,
							CourseID = id,
						};
						_context.Chapters.Add(chapter1);
						_context.SaveChanges();
					}

				}
			}
			List<Chapter> listC1 = _context.Chapters.Where(c => c.CourseID == id).ToList();
			List<Chapter> chaptersToDelete = new List<Chapter>();
			foreach (Chapter s in listC1)
			{
				if (!chapter.Contains(s.Name))
				{
					chaptersToDelete.Add(s);
				}

			}
			_context.Chapters.RemoveRange(chaptersToDelete);
			_context.SaveChanges();




			return RedirectToAction("Index");
		}
		public async Task<IActionResult> EditChapter(int? id)
		{
			ViewBag.listLesson = _context.Lessons.Where(c => c.ChapterID == id).ToList();
			ViewBag.courseID = _context.Chapters.Where(c => c.ID == id).Select(c => c.CourseID).FirstOrDefault();
			ViewBag.id = id;
			return View();
		}
		public async Task<IActionResult> CreateLesson(int id)
		{
			ViewBag.chapterId = id;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateLesson(Lesson lesson, int id)
		{
			Lesson course1 = new Lesson
			{
				Name = lesson.Name,
				Content = "",
				Link = lesson.Link,
				Date = DateTime.Now,
				NumOfLike = 0,
				Type = lesson.Type,
				ChapterID = id,
			};
			_context.Add(course1);
			_context.SaveChanges();

			ViewBag.listLesson = _context.Lessons.Where(c => c.ChapterID == id).ToList();
			ViewBag.courseID = _context.Chapters.Where(c => c.ID == id).Select(c => c.CourseID).FirstOrDefault();
			ViewBag.id = id;

			return View("EditChapter");

		}

		public async Task<IActionResult> DeleteLesson(int? id)
		{
			if (id == null || _context.Lessons == null)
			{
				return NotFound();
			}

			var cour = await _context.Lessons
				.FirstOrDefaultAsync(m => m.ID == id);

			if (cour == null)
			{
				return NotFound();
			}

			return View(cour);
		}

		// POST: Questions/Delete/5
		[HttpPost, ActionName("DeleteLesson")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed1(int id, int ChapterID)
		{
			if (_context.Lessons == null)
			{
				return Problem("Entity set 'MyDbContext.Lesson'  is null.");
			}
			var cour = await _context.Lessons.FindAsync(id);
			if (cour != null)
			{
				_context.Lessons.Remove(cour);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(EditChapter), new { id = ChapterID });
		}
		public async Task<IActionResult> EditLesson(int? id)
		{
			if (id == null || _context.Lessons == null)
			{
				return NotFound();
			}
			var lessons = from c in _context.Lessons
						  where c.ID == id
						  select new Lesson
						  {
							  ID = c.ID,
							  Name = c.Name,
							  Date = c.Date,
							  Type = c.Type,
							  Link = c.Link,
						  };
			//ViewBag.Lesson = lessons.FirstOrDefault();
			return View(lessons.FirstOrDefault());
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditLesson(Lesson lesson)
		{
			//Lesson less = new Lesson
			//{
			//	ID = lesson.ID,
			//	Name = lesson.Name,
			//	Content = "",
			//	NumOfLike = lesson.NumOfLike,
			//	Link = lesson.Link,
			//	Date = lesson.Date,
			//	Type = lesson.Type,

			//};
			Lesson lessonU= _context.Lessons.FirstOrDefault(l=>l.ID==lesson.ID);
			lessonU.Name=lesson.Name;
			lessonU.Link=lesson.Link;
			lessonU.Type=lesson.Type;
			_context.Update(lessonU);
			_context.SaveChanges();

			ViewBag.listLesson = _context.Lessons.Where(c => c.ChapterID == lessonU.ChapterID).ToList();
			ViewBag.courseID = _context.Chapters.Where(c => c.ID == lessonU.ChapterID).Select(c => c.CourseID).FirstOrDefault();
			ViewBag.id = lessonU.ChapterID;
			return View("EditChapter");
		}



	}
}
