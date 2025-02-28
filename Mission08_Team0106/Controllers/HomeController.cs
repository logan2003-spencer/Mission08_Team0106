using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0106.Models;

namespace Mission08_Team0106.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
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



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}