using System.Collections.Generic;

namespace KT_7
{
    public class Graph
    {
        public int VertexCount { get; }
        public List<FlightEdge>[] AdjacencyList { get; }
        public bool[] IsChargingStation { get; }

        public Graph(int vertexCount)
        {
            VertexCount = vertexCount;
            AdjacencyList = new List<FlightEdge>[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                AdjacencyList[i] = new List<FlightEdge>();
            }
            IsChargingStation = new bool[vertexCount];
        }

        public void AddEdge(int source, int target, int cost, int batteryCost)
        {
            FlightEdge edge = new FlightEdge(target, cost, batteryCost);
            AdjacencyList[source].Add(edge);
        }

        public void SetChargingStation(int vertex, bool isStation)
        {
            IsChargingStation[vertex] = isStation;
        }
    }
}
