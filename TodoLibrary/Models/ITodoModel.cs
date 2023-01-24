namespace TodoLibrary.Models
{
    public interface ITodoModel
    {
        int Id { get; set; }
        string? Task { get; set; }
        int AssignedTo { get; set; }
        bool IsComplete { get; set; }
    }
}