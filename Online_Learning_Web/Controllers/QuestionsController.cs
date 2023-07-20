using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Learning_Web.Models;
using Online_Learning_Web.ViewModel;

namespace Online_Learning_Web.Controllers
{
    [Authorize (Roles = "Admin")]
    public class QuestionsController : Controller
    {
        private readonly MyDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public QuestionsController(MyDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Questions.Include(q => q.Lesson)
                                    .ThenInclude(q => q.Chapter)
                                    .ThenInclude(q => q.Course);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.Include(q => q.Lesson)
                                    .ThenInclude(q => q.Chapter)
                                    .ThenInclude(q => q.Course)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            //ViewData["LessonID"] = new SelectList(_context.Lessons, "ID", "ID");
            var listCourse = _context.Courses.ToList();
            ViewBag.listCourse = listCourse;
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddQuestionVM addQuestionVM, int courseID)
        {
            if (ModelState.IsValid)
            {

                Question question = new Question
                {
                    Content = addQuestionVM.Content,
                    explain = addQuestionVM.Explain,
                    LessonID = addQuestionVM.LessonID,
                };
                _context.Add(question);
                _context.SaveChanges();
                //get current quesID
                var questions = _context.Questions.ToList();
                int quesID = 0;
                foreach (Question q in questions)
                {
                    if (q.ID > quesID) quesID = q.ID;
                }

                var answer = addQuestionVM.Answer.ToList();
                foreach (string a in answer)
                {
                    Answer an = new Answer
                    {
                        Content = a,
                        QuestionID = quesID,
                    };
                    _context.Add(an);
                }
                _context.SaveChanges();
                int indexCor = int.Parse(addQuestionVM.CorrectAnswer);
                CorrectAnswer co = new CorrectAnswer
                {
                    Content = answer[indexCor],
                    QuestionID = quesID,
                };
                _context.Add(co);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (!string.IsNullOrEmpty(courseID + ""))
            {
                //Get list course
                var listCourse = _context.Courses.ToList();
                ViewBag.listCourse = listCourse;

                //Get lesson type 'practice' by courseID
                var listLesson = from c in _context.Courses
                                 join ct in _context.Chapters on c.Id equals ct.CourseID
                                 join l in _context.Lessons on ct.ID equals l.ChapterID
                                 where (c.Id == courseID) && (l.Type.Equals("practice"))
                                 select l;
                ViewBag.listLesson = listLesson.ToList();
                ViewBag.courseID = courseID;
                return View("Create");
            }

            return View("Index");

        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            var qr = from q in _context.Questions
                     join an in _context.Answers on q.ID equals an.QuestionID
                     join co in _context.CorrectAnswers on q.ID equals co.QuestionID
                     join l in _context.Lessons on q.LessonID equals l.ID
                     where q.ID == id
                     select new AddQuestionVM {
                         LessonID = l.ID,
                         Content = q.Content,
                         CorrectAnswer = co.Content,
                         Explain = q.explain,
                     };
            ViewBag.listAnswer = _context.Answers.Where(a => a.QuestionID == id).ToList();
            ViewBag.Question = qr.FirstOrDefault();
            ViewBag.id = id;
            if (qr == null)
            {
                return NotFound();
            }
            //ViewData["LessonID"] = new SelectList(_context.Lessons, "ID", "ID", question.LessonID);
            return View();
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddQuestionVM addQuestionVM, int id)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            var question = _context.Questions.Where(q => q.ID == id).FirstOrDefault();
            //update question
            question.explain = addQuestionVM.Explain;
            question.Content = addQuestionVM.Content;
            _context.Update(question);
            _context.SaveChanges();
            //update anwer;
            var answer = _context.Answers.Where(a => a.QuestionID == id).ToList();
            int i = 0;
            foreach (var ans in answer)
            {
                ans.Content = addQuestionVM.Answer[i++];
                _context.Update(ans);
                _context.SaveChanges();
            }
            

            return RedirectToAction("Index");
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Lesson)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'MyDbContext.Questions'  is null.");
            }
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Doing question
        public IActionResult DoingQuestion(int ?lessonID, int? courseID)
        {
            List<DoingQuestionVM> listQuestion = new List<DoingQuestionVM>();
            var qr = from q in _context.Questions
                     join l in _context.Lessons on q.LessonID equals l.ID
                     where l.ID == lessonID
                     select q;
            foreach(Question q in qr.ToList())
            {
                DoingQuestionVM dq = new DoingQuestionVM();
                var qr1 = _context.Answers.Where(a => a.QuestionID == q.ID);
                CorrectAnswer cr = _context.CorrectAnswers.FirstOrDefault(c => c.QuestionID == q.ID);
                dq.Question = q;
                dq.Answers = qr1.ToList();
                dq.CorrectAnswer = cr;
                listQuestion.Add(dq);
            }
            var listAppUserQuestion = _context.AppUserQuestions.Where(a => a.AppUsersId.Equals(_userManager.GetUserId(User)));
            ViewBag.lesson = _context.Lessons.FirstOrDefault(l => l.ID == lessonID);
            ViewBag.lessonID = lessonID;
            ViewBag.listQuestion = listQuestion;
            ViewBag.listAppUserQuestion = listAppUserQuestion;
            ViewBag.courseID = courseID;
            return View();
        }

        [HttpPost]
        public IActionResult DoingQuestion(int? lessonID, int questionID, string? answer)
        {
            CorrectAnswer correctAns = _context.CorrectAnswers.FirstOrDefault(c => c.QuestionID == questionID);
            bool rs = false;
            if (answer.Equals(correctAns.Content))
            {
                rs = true;
            }
            AppUserQuestions auq = new AppUserQuestions()
            {
                AppUsersId = _userManager.GetUserId(User),
                QuestionsId = questionID,
                Answer = answer,
                TrueOrFalse = rs,
            };
            _context.Add(auq);
            _context.SaveChanges();

            return Redirect($"/Questions/DoingQuestion?lessonID={lessonID}");
        }
        private bool QuestionExists(int id)
        {
            return (_context.Questions?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
