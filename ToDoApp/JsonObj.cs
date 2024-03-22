using System.Text.Json;

public class ToDoJson
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool Urgent { get; set; }
    public bool Pending { get; set; }
    public DateTime CreationTime { get; set; }
}
