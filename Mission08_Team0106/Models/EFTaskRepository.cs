using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0106.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public EFTaskRepository(TaskContext context)
        {
            _context = context;
        }

        public IEnumerable<HabitTask> GetAllTasks()
        {
            return _context.Tasks.Include(t => t.Category).ToList();
        }

        public void AddTask(HabitTask task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public HabitTask? GetTaskById(int id)
        {
            return _context.Tasks.Include(t => t.Category).FirstOrDefault(t => t.TaskId == id);
        }

        public void UpdateTask(HabitTask task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}


