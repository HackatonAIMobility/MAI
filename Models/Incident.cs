namespace MAI.Models;
public class Incident
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string StartStation { get; set; } = string.Empty;
    public string EndStation { get; set; } = string.Empty;
    public Priority Priority { get; set; } = Priority.MESSAGE;
}