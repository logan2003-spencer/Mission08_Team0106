﻿namespace Mission08_Team0106.Models
{
    public interface ITaskRepository
    {
        IQueryable<HabitTask> Tasks { get; }
        IEnumerable<HabitTask> GetAllTasks();
        HabitTask? GetTaskById(int id);
        void AddTask(HabitTask task);
        void UpdateTask(HabitTask task);
        void DeleteTask(int id);
        IEnumerable<Category> GetCategories();  // for dropdowns
    }
}


