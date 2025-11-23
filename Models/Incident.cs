namespace MAI.Models;
/// <summary>
/// Represents an incident reported within the metro system.
/// Incidents can include delays, successful travels, or other events affecting passenger experience.
/// </summary>
public class Incident
{
    /// <summary>
    /// Gets or sets the unique identifier for the incident.
    /// A new GUID is generated for each incident by default.
    /// </summary>
    public string Id { get; set; } = Guid.NewGuid().ToString();
    /// <summary>
    /// Gets or sets the title of the incident, providing a brief summary.
    /// </summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets a short description of the incident, suitable for summaries or notifications.
    /// </summary>
    public string ShortDescription { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets a detailed description of the incident.
    /// </summary>
    public string Description { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the timestamp when the incident occurred or was reported.
    /// Defaults to <see cref="DateTime.UtcNow"/>.
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    /// <summary>
    /// Gets or sets the name of the station where the incident started or is relevant to.
    /// </summary>
    public string StartStation { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the name of the station where the incident ended or is relevant to, if applicable.
    /// </summary>
    public string EndStation { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the priority level of the incident, indicating its severity or importance.
    /// Defaults to <see cref="Priority.MESSAGE"/>.
    /// </summary>
    public Priority Priority { get; set; } = Priority.MESSAGE;
}