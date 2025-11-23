namespace MAI.Models;
/// <summary>
/// Represents a report submission from a user, detailing the success status, timestamp,
/// form title, and any associated comments.
/// </summary>
public class Report
{
    /// <summary>
    /// Gets or sets a value indicating whether the reported operation was successful.
    /// </summary>
    public bool Success { get; set; }
    /// <summary>
    /// Gets or sets the timestamp when the report was created.
    /// </summary>
    public DateTime Timestamp { get; set; }
    /// <summary>
    /// Gets or sets the title of the form from which the report originated.
    /// </summary>
    public string FormTitle { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets any additional comments or details provided in the report.
    /// </summary>
    public string Comment { get; set; } = string.Empty;
}