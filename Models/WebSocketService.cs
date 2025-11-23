using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using MAI.Services;

namespace MAI.Models
{
    /// <summary>
    /// Manages WebSocket connections for receiving incident updates and caching them.
    /// This service connects to a WebSocket server, receives incident messages,
    /// caches unique incidents, and triggers notifications.
    /// </summary>
    public class WebSocketService
    {
        private readonly ClientWebSocket _webSocket = new ClientWebSocket();
        private readonly IMemoryCache _cache;
        private readonly NotificationService _notificationService;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        /// <summary>
        /// Occurs when a new incident is received from the WebSocket.
        /// </summary>
        public event System.Action<Incident>? OnIncidentReceived;

        private const string IncidentIdsCacheKey = "IncidentIds";

        /// <summary>
        /// Retrieves all cached incidents.
        /// </summary>
        /// <returns>A list of <see cref="Incident"/> objects currently in the cache.</returns>
        public List<Incident> GetAllIncidents()
        {
            var incidentIds = _cache.Get<List<string>>(IncidentIdsCacheKey);
            if (incidentIds == null)
            {
                return new List<Incident>();
            }

            var incidents = new List<Incident>();
            foreach (var id in incidentIds)
            {
                if (_cache.TryGetValue(id, out Incident incident))
                {
                    incidents.Add(incident);
                }
            }
            return incidents;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="WebSocketService"/> class.
        /// </summary>
        /// <param name="cache">The <see cref="IMemoryCache"/> instance for caching incidents.</param>
        /// <param name="notificationService">The <see cref="NotificationService"/> for displaying notifications.</param>
        public WebSocketService(IMemoryCache cache, NotificationService notificationService)
        {
            _cache = cache;
            _notificationService = notificationService;
        }

        /// <summary>
        /// Establishes a WebSocket connection to the specified URI and starts listening for messages.
        /// </summary>
        /// <param name="uri">The URI of the WebSocket server.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous connection operation.</returns>
        public async Task ConnectAsync(string uri)
        {
            try
            {
                await _webSocket.ConnectAsync(new System.Uri(uri), _cancellationTokenSource.Token);
                await ReceiveMessagesAsync();
            }
            catch (System.Exception ex)
            {
                // Handle connection errors
                System.Diagnostics.Debug.WriteLine($"WebSocket connection error: {ex.Message}");
            }
        }

        /// <summary>
        /// Continuously receives messages from the WebSocket connection.
        /// Deserializes incoming messages as <see cref="Incident"/> objects,
        /// caches them, and triggers the <see cref="OnIncidentReceived"/> event and a notification.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous message receiving operation.</returns>
        private async Task ReceiveMessagesAsync()
        {
            var buffer = new byte[1024 * 4];
            while (_webSocket.State == WebSocketState.Open)
            {
                var result = await _webSocket.ReceiveAsync(new System.ArraySegment<byte>(buffer), _cancellationTokenSource.Token);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    try
                    {
                        var incidentWrapper = JsonSerializer.Deserialize<IncidentWrapper>(message, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        if (incidentWrapper?.type == "incident" && incidentWrapper.payload != null)
                        {
                            var incident = incidentWrapper.payload;
                            var incidentIds = _cache.Get<List<string>>(IncidentIdsCacheKey) ?? new List<string>();
                            if (!incidentIds.Contains(incident.Id))
                            {
                                incidentIds.Add(incident.Id);
                                _cache.Set(IncidentIdsCacheKey, incidentIds);
                                _cache.Set(incident.Id, incident, System.TimeSpan.FromMinutes(30)); 
                                OnIncidentReceived?.Invoke(incident); 
                                await _notificationService.ShowNotification(incident.Title, incident.ShortDescription); 
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error processing message: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Closes the WebSocket connection if it is currently open.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous disconnection operation.</returns>
        public async Task DisconnectAsync()
        {
            if (_webSocket.State == WebSocketState.Open)
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", _cancellationTokenSource.Token);
            }
        }
    }

    /// <summary>
    /// Represents a wrapper for incident data received over WebSocket.
    /// This structure is used for deserializing the JSON payload from the WebSocket server.
    /// </summary>
    public class IncidentWrapper
    {
        /// <summary>
        /// Gets or sets the type of the message, e.g., "incident".
        /// </summary>
        public string type { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the <see cref="Incident"/> payload contained within the message.
        /// </summary>
        public Incident payload { get; set; } = new Incident();
    }
}
