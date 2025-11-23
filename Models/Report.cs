namespace MAI.Models;
public class Report
{
    public bool Success { get; set; }
    public DateTime Timestamp { get; set; }
    public string FormTitle { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
}