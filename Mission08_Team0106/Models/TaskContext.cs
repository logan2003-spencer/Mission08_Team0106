using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0106.Models
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use your connection string here
            optionsBuilder.UseSqlite("Data Source=TaskDatabase.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            // You can add any additional configurations here
        }
    }
}
