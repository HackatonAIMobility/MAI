using System.Collections.Generic;
using System.Linq;

namespace MAI.Models
{
    public class MetroService
    {
        private readonly Dictionary<string, List<string>> _adjacencyList;

        public MetroService()
        {
            _adjacencyList = BuildAdjacencyList();
        }

        private Dictionary<string, List<string>> BuildAdjacencyList()
        {
            var adjacencyList = new Dictionary<string, List<string>>();

            foreach (var stationName in MetroData.Stations.Keys)
            {
                adjacencyList[stationName] = new List<string>();
            }

            foreach (var line in MetroData.Lines)
            {
                for (int i = 0; i < line.Stations.Count; i++)
                {
                    if (i > 0)
                    {
                        adjacencyList[line.Stations[i]].Add(line.Stations[i - 1]);
                    }
                    if (i < line.Stations.Count - 1)
                    {
                        adjacencyList[line.Stations[i]].Add(line.Stations[i + 1]);
                    }
                }
            }
            
            // Add transfer connections
            var stationsOnLines = new Dictionary<string, List<string>>();
            foreach (var line in MetroData.Lines)
            {
                foreach (var stationName in line.Stations)
                {
                    if (!stationsOnLines.ContainsKey(stationName))
                    {
                        stationsOnLines[stationName] = new List<string>();
                    }
                    stationsOnLines[stationName].Add(line.Name);
                }
            }

            foreach (var stationName in stationsOnLines.Keys)
            {
                if (stationsOnLines[stationName].Count > 1)
                {
                    // This is a transfer station
                    // The neighbors are already connected on their respective lines
                    // No special handling needed for this simple BFS
                }
            }


            return adjacencyList;
        }

        public List<Station> FindRoute(string startStationName, string endStationName)
        {
            if (!_adjacencyList.ContainsKey(startStationName) || !_adjacencyList.ContainsKey(endStationName))
            {
                return null; // Or throw an exception
            }

            var queue = new Queue<List<string>>();
            queue.Enqueue(new List<string> { startStationName });

            var visited = new HashSet<string> { startStationName };

            while (queue.Count > 0)
            {
                var path = queue.Dequeue();
                var lastStation = path.Last();

                if (lastStation == endStationName)
                {
                    return path.Select(stationName => MetroData.Stations[stationName]).ToList();
                }

                foreach (var neighbor in _adjacencyList[lastStation])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        var newPath = new List<string>(path);
                        newPath.Add(neighbor);
                        queue.Enqueue(newPath);
                    }
                }
            }

            return null; // No path found
        }
    }
}
