using System;
using System.Collections.Generic;

namespace KT_7
{
    public class DroneRouter
    {
        public static int MinCostRoute(Graph graph, int start, int destination, int batteryCapacity)
        {
            if (graph == null || start < 0 || destination < 0 || start >= graph.VertexCount || destination >= graph.VertexCount)
            {
                return -1;
            }

            int[,] minCost = new int[graph.VertexCount, batteryCapacity + 1];
            for (int i = 0; i < graph.VertexCount; i++)
            {
                for (int j = 0; j <= batteryCapacity; j++)
                {
                    minCost[i, j] = int.MaxValue;
                }
            }

            PriorityQueue<(int vertex, int battery), int> pq = new PriorityQueue<(int vertex, int battery), int>();

            int initialBattery = batteryCapacity;
            minCost[start, initialBattery] = 0;
            pq.Enqueue((start, initialBattery), 0);

            while (pq.Count > 0)
            {
                (int vertex, int battery) current = pq.Dequeue();
                int vertex = current.vertex;
                int battery = current.battery;

                if (vertex == destination)
                {
                    return minCost[vertex, battery];
                }

                if (minCost[vertex, battery] == int.MaxValue)
                {
                    continue;
                }

                List<FlightEdge> edges = graph.AdjacencyList[vertex];
                for (int i = 0; i < edges.Count; i++)
                {
                    FlightEdge edge = edges[i];
                    if (battery >= edge.BatteryCost)
                    {
                        int nextVertex = edge.Target;
                        int nextBattery = battery - edge.BatteryCost;

                        if (graph.IsChargingStation[nextVertex])
                        {
                            nextBattery = batteryCapacity;
                        }

                        int nextCost = minCost[vertex, battery] + edge.Cost;

                        if (nextCost < minCost[nextVertex, nextBattery])
                        {
                            minCost[nextVertex, nextBattery] = nextCost;
                            pq.Enqueue((nextVertex, nextBattery), nextCost);
                        }
                    }
                }
            }

            return -1;
        }
    }
}
