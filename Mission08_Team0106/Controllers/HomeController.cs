using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0106.Models;

namespace Mission08_Team0106.Controllers;

public class QuadrantsController : Controller
{
    private readonly ApplicationDbContext _context;

    public QuadrantsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var tasks = _context.QuadrantTasks.ToList();
        return View(tasks);    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    // Display the form for adding or editing a task
    public IActionResult AddEditTask(int? id)
    {
        var model = new HabitTask();
        if (id.HasValue)
        {
            // Dummy data for editing - in reality, you'd get this from a database
            model = new HabitTask
            {
                TaskId = id.Value,
                Title = "Sample Task",
                DueDate = DateTime.Today,
                Quadrant = 2,
                Category = 3,
                Completed = true
            };
        }
        return View(model);
    }
    
    [HttpPost]
    public IActionResult Update(int id, string description, int quadrant)
    {
        var task = _context.QuadrantTasks.Find(id);
        if (task != null)
        {
            task.Description = description;
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
        var task = _context.QuadrantTasks.Find(id);
        if (task != null)
        {
            _context.QuadrantTasks.Remove(task);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
