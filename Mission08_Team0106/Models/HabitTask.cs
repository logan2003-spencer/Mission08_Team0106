using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0106.Models
{
    public class HabitTask
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime? DueDate { get; set; }
        public int? Quadrant { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        
        public Category? Category { get; set; }
        public bool Completed { get; set; }
    }
}
