using Microsoft.AspNetCore.Mvc;
using Mission08_Team0106.Models;
using System.Linq;

namespace Mission08_Team0106.Controllers
{
    public class QuadrantsController : Controller
    {
        private readonly ITaskRepository _repository;
        public QuadrantsController(ITaskRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var tasks = _repository.GetAllTasks().ToList();
            return View(tasks);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddEditTask(int? id)
        {
            var task = id == null ? new HabitTask() : _repository.GetTaskById(id.Value);
            ViewBag.Categories = _repository.GetCategories().OrderBy(c => c.Name).ToList();
            return View(task);
        }
        [HttpPost]
        public IActionResult AddEditTask(HabitTask habitTask)
        {
            
            if (ModelState.IsValid)
            {
                if (habitTask.TaskId == 0)
                {
                    _repository.AddTask(habitTask);
                }
                else
                {
                    _repository.UpdateTask(habitTask);
                }

                // Force saving changes to the database

                return RedirectToAction("Index");
            }

            // Debug: Print validation errors
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Validation Error: {error.ErrorMessage}");
            }

            // Always re-populate dropdown
            ViewBag.Categories = _repository.GetCategories().OrderBy(c => c.Name).ToList();

            return View(habitTask);
        }
        public IActionResult Quadrant()
        {
            var tasks = _repository.GetAllTasks().ToList();
            return View(tasks);
        }
        [HttpPost]
        public IActionResult Update(int id, int quadrant)
        {
            var task = _repository.GetTaskById(id);
            if (task != null)
            {
                task.Quadrant = quadrant;
                _repository.UpdateTask(task);
            }
            return RedirectToAction("Quadrant");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.DeleteTask(id);
            return RedirectToAction("Quadrant");
        }
    }
}
