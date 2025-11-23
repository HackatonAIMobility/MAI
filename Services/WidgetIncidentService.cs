using MAI.Models;
using Microsoft.Maui.Devices.Sensors;
using System.Net.Http.Json;
using System.Text.Json;

namespace MAI.Services
{
    public class WidgetIncidentService
    {
        private readonly HttpClient _httpClient;

        public WidgetIncidentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task ReportTravelIncident(bool isTravelSuccessful)
        {
            // 1. Get current location
            var currentLocation = await GetCurrentLocation();
            if (currentLocation == null)
            {
                // Handle case where location cannot be obtained
                Console.WriteLine("Unable to retrieve current location.");
                return;
            }

            // 2. Find nearest station
            var nearestStationName = FindNearestMetroStation(currentLocation);
            if (string.IsNullOrEmpty(nearestStationName))
            {
                Console.WriteLine("Unable to find nearest metro station.");
                return;
            }

            // 3. Construct Incident object
            var incident = new Incident
            {
                Title = "Fast Report",
                Description = isTravelSuccessful ? "El usuario reporta que su viaje fue exitoso." : "El usuario reporta que su viaje no fue exitoso.",
                ShortDescription = isTravelSuccessful ? "Viaje exitoso." : "Viaje no exitoso.",
                Timestamp = DateTime.UtcNow,
                Priority = Priority.MEDIUM,
                StartStation = nearestStationName,
                EndStation = string.Empty // Not setting EndStation for this quick report
            };

            // 4. Submit Incident
            await SubmitIncident(incident);
        }

        private async Task<Location?> GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var location = await Geolocation.Default.GetLocationAsync(request);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
                return location;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Console.WriteLine($"Geolocation not supported: {fnsEx.Message}");
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Console.WriteLine($"Geolocation permission denied: {pEx.Message}");
            }
            catch (Exception ex)
            {
                // Unable to get location
                Console.WriteLine($"Unable to get location: {ex.Message}");
            }
            return null;
        }

        private string FindNearestMetroStation(Location currentLocation)
        {
            string nearestStation = string.Empty;
            double minDistance = double.MaxValue;

            foreach (var station in MetroStationsStatic.MetroStations)
            {
                // Calculate distance using Haversine formula or Location.CalculateDistance
                // Using Location.CalculateDistance for simplicity and accuracy
                double distance = Location.CalculateDistance(
                    currentLocation.Latitude, currentLocation.Longitude,
                    station.Latitude, station.Longitude,
                    DistanceUnits.Kilometers);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestStation = station.Title;
                }
            }
            return nearestStation;
        }

        private async Task SubmitIncident(Incident incident)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(incident, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Assuming FastAPI endpoint
                // TODO: Make this URL configurable, or use a constant from a shared location.
                var response = await _httpClient.PostAsync("http://10.110.168.15:8000/incidents", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Incident reported successfully from widget!");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error reporting incident from widget: {response.StatusCode} - {errorContent}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception submitting incident from widget: {ex.Message}");
            }
        }
    }
}
