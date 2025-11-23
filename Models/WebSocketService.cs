using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace MAI.Models
{
    public class WebSocketService
    {
        private readonly ClientWebSocket _webSocket = new ClientWebSocket();
        private readonly IMemoryCache _cache;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public event System.Action<Incident>? OnIncidentReceived;

        private const string IncidentIdsCacheKey = "IncidentIds";

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


        public WebSocketService(IMemoryCache cache)
        {
            _cache = cache;
        }

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

        public async Task DisconnectAsync()
        {
            if (_webSocket.State == WebSocketState.Open)
            {
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", _cancellationTokenSource.Token);
            }
        }
    }

    public class IncidentWrapper
    {
        public string type { get; set; } = string.Empty;
        public Incident payload { get; set; } = new Incident();
    }
}
