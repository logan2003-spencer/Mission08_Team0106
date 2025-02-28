using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0106.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        [Required]
        public string Task { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        [Required]
        [EnumDataType(typeof(Category))]
        public Category? Category { get; set; }

        public bool Completed { get; set; }
    }
}
