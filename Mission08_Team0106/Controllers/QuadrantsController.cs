using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0106.Models;

namespace Mission08_Team0106.Controllers;


    public class QuadrantsController : Controller
    {
        private readonly ITaskRepository _repository;

        public QuadrantsController(ITaskRepository repository)
        {
            _repository = repository;
        }
    
    public IActionResult Index()
    {
        var tasks = _repository.GetAllTasks();
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
            return RedirectToAction("Index");
        }

        ViewBag.Categories = _repository.GetCategories().OrderBy(c => c.Name).ToList();
        return View(habitTask);
    }
    
    
    
    [HttpGet]
    public IActionResult Quadrant()
    {
        var tasks = _context.Tasks.
            ToList();
        return View(tasks); // Explicitly set the path
    }
    
    [HttpPost]
    public IActionResult Update(int id, string description, int quadrant)
    {
        var task = _context.Tasks.Find(id);
        if (task != null)
        {
            // task.Description = description;
            task.Quadrant = quadrant;
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }


    // Handle the form submission
    [HttpPost]
    public IActionResult SaveTask(HabitTask model)
    {
        if (ModelState.IsValid)
        {
            // For demonstration, we'll just return to the same view
            // Normally, you'd save the data to a database here
            TempData["SuccessMessage"] = "Task saved successfully!";
            return RedirectToAction("AddEditTask");
        }

        return View("AddEditTask", model);
    }



    [HttpPost]
    public IActionResult Delete(int id)
    {
        _repository.DeleteTask(id);
        return RedirectToAction("Index");
    }

    public IActionResult Quadrant()
    {
        var tasks = _repository.GetAllTasks();
        return View(tasks);
    }
    
    
}
