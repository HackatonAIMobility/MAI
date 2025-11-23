using System.Collections.Generic;
using System.Linq;

namespace MAI.Models
{
    /// <summary>
    /// Provides services related to the metro system, such as finding routes between stations.
    /// It builds and utilizes an adjacency list to represent the metro network.
    /// </summary>
    public class MetroService
    {
        private readonly Dictionary<string, List<string>> _adjacencyList;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetroService"/> class.
        /// It constructs the metro network's adjacency list based on <see cref="MetroData"/>.
        /// </summary>
        public MetroService()
        {
            _adjacencyList = BuildAdjacencyList();
        }

        /// <summary>
        /// Builds an adjacency list representation of the metro network.
        /// Each key in the dictionary is a station name, and its value is a list of directly connected stations.
        /// </summary>
        /// <returns>A <see cref="Dictionary{TKey, TValue}"/> representing the metro network's adjacency list.</returns>
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
            
            // Add transfer connections (Logic for this is commented out, as simple BFS doesn't need explicit transfer edges)
            // The existing logic already connects stations along a line, which is sufficient for basic BFS.
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

        /// <summary>
        /// Finds a route between a starting station and an ending station using a Breadth-First Search (BFS) algorithm.
        /// </summary>
        /// <param name="startStationName">The name of the starting metro station.</param>
        /// <param name="endStationName">The name of the ending metro station.</param>
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="Station"/> objects representing the found route,
        /// or <see langword="null"/> if no path is found or if station names are invalid.
        /// </returns>
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
