namespace MAI.Models;
/// <summary>
/// Defines the priority levels for incidents or messages within the application.
/// </summary>
public enum Priority : int
{
    /// <summary>
    /// Represents a high-priority incident or message.
    /// </summary>
    HIGH = 1,
    /// <summary>
    /// Represents a medium-priority incident or message.
    /// </summary>
    MEDIUM = 2,
    /// <summary>
    /// Represents a low-priority incident or message.
    /// </summary>
    LOW = 3,
    /// <summary>
    /// Represents a general message or informational priority.
    /// </summary>
    MESSAGE = 4
}