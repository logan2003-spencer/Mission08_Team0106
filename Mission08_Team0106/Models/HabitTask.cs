using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0106.Models
{
    public class HabitTask
    {
        [Key]
        public int TaskId { get; set; }
        public string Title { get; set; }
        public DateTime? DueDate { get; set; }
        public int? Quadrant { get; set; }
        public int? Category { get; set; }
        public bool Completed { get; set; }
    }
}
