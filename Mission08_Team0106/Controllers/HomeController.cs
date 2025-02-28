using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0106.Models;

// Controllers needed:
// httpget the form from database (viewbag the Category)
// the page where all records are shown (where edit and delete buttons are)
// httpget and post for edit and delete buttons

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
        return View(tasks);
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
