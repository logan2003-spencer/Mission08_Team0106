using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0106.Models
{
    public class TaskContext : DbContext
    {
        public DbSet<HabitTask> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HabitTask>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Home" },
                new Category { CategoryId = 2, Name = "School" },
                new Category { CategoryId = 3, Name = "Work" },
                new Category { CategoryId = 4, Name = "Church" }
            );
        }
    }
}

