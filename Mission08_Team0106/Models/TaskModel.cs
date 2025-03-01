namespace Mission08_Team0106.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TaskModel
{
    [Key]
    public int TaskId { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public int Quadrant { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }

    public bool Completed { get; set; }
}

