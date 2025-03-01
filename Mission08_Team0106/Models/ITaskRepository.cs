namespace Mission08_Team0106.Models
{
    public class ITaskRepository
    {
        string Task { get; set; }
        DateTime DueDate { get; set; }
        int Quadrant { get; set; }
        Category? Category { get; set; }
        bool Completed { get; set; }
    }
}
