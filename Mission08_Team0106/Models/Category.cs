using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0106.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        
        public ICollection<HabitTask> Tasks { get; set; }
    }
}
