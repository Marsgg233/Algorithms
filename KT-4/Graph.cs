using System.Collections.Generic;

namespace KT_4
{
    public class Graph
    {
        private Dictionary<int, List<Edge>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<int, List<Edge>>();
        }

        public void AddVertex(int vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new List<Edge>();
            }
        }

        public void AddEdge(int from, int to, int weight)
        {
            AddVertex(from);
            AddVertex(to);
            adjacencyList[from].Add(new Edge(to, weight));
            adjacencyList[to].Add(new Edge(from, weight));
        }

        public void RemoveEdge(int from, int to)
        {
            if (adjacencyList.ContainsKey(from))
            {
                adjacencyList[from].RemoveAll(e => e.To == to);
            }
            if (adjacencyList.ContainsKey(to))
            {
                adjacencyList[to].RemoveAll(e => e.To == from);
            }
        }

        public List<int> GetVertices()
        {
            return new List<int>(adjacencyList.Keys);
        }

        public List<int> Dfs(int start)
        {
            List<int> visitedOrder = new List<int>();
            HashSet<int> visited = new HashSet<int>();

            if (!adjacencyList.ContainsKey(start))
            {
                return visitedOrder;
            }

            DfsRecursive(start, visited, visitedOrder);
            return visitedOrder;
        }

        private void DfsRecursive(int current, HashSet<int> visited, List<int> visitedOrder)
        {
            visited.Add(current);
            visitedOrder.Add(current);

            List<Edge> neighbors = adjacencyList[current];
            for (int i = 0; i < neighbors.Count; i++)
            {
                Edge edge = neighbors[i];
                if (!visited.Contains(edge.To))
                {
                    DfsRecursive(edge.To, visited, visitedOrder);
                }
            }
        }

        public List<int> Bfs(int start)
        {
            List<int> visitedOrder = new List<int>();
            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();

            if (!adjacencyList.ContainsKey(start))
            {
                return visitedOrder;
            }

            visited.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                visitedOrder.Add(current);

                List<Edge> neighbors = adjacencyList[current];
                for (int i = 0; i < neighbors.Count; i++)
                {
                    Edge edge = neighbors[i];
                    if (!visited.Contains(edge.To))
                    {
                        visited.Add(edge.To);
                        queue.Enqueue(edge.To);
                    }
                }
            }

            return visitedOrder;
        }

        public int CountConnectedComponents()
        {
            HashSet<int> visited = new HashSet<int>();
            int count = 0;
            List<int> vertices = GetVertices();

            for (int i = 0; i < vertices.Count; i++)
            {
                int vertex = vertices[i];
                if (!visited.Contains(vertex))
                {
                    count++;
                    DfsComponent(vertex, visited);
                }
            }

            return count;
        }

        private void DfsComponent(int current, HashSet<int> visited)
        {
            visited.Add(current);
            List<Edge> neighbors = adjacencyList[current];
            for (int i = 0; i < neighbors.Count; i++)
            {
                Edge edge = neighbors[i];
                if (!visited.Contains(edge.To))
                {
                    DfsComponent(edge.To, visited);
                }
            }
        }

        public bool HasCycle()
        {
            HashSet<int> visited = new HashSet<int>();
            List<int> vertices = GetVertices();

            for (int i = 0; i < vertices.Count; i++)
            {
                int vertex = vertices[i];
                if (!visited.Contains(vertex))
                {
                    if (HasCycleBfs(vertex, visited))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool HasCycleBfs(int start, HashSet<int> visited)
        {
            Dictionary<int, int> parent = new Dictionary<int, int>();
            Queue<int> queue = new Queue<int>();

            visited.Add(start);
            queue.Enqueue(start);
            parent[start] = -1;

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                List<Edge> neighbors = adjacencyList[current];

                for (int i = 0; i < neighbors.Count; i++)
                {
                    Edge edge = neighbors[i];
                    int neighbor = edge.To;

                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        parent[neighbor] = current;
                        queue.Enqueue(neighbor);
                    }
                    else if (parent.ContainsKey(current) && parent[current] != neighbor)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Dictionary<int, int> Dijkstra(int start)
        {
            Dictionary<int, int> distances = new Dictionary<int, int>();
            List<int> vertices = GetVertices();

            for (int i = 0; i < vertices.Count; i++)
            {
                distances[vertices[i]] = int.MaxValue;
            }

            if (!distances.ContainsKey(start))
            {
                return distances;
            }

            distances[start] = 0;
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            pq.Enqueue(start, 0);

            while (pq.Count > 0)
            {
                int current = pq.Dequeue();

                List<Edge> neighbors = adjacencyList[current];
                for (int i = 0; i < neighbors.Count; i++)
                {
                    Edge edge = neighbors[i];
                    int neighbor = edge.To;
                    int weight = edge.Weight;

                    int newDistance = distances[current] + weight;
                    if (distances[current] != int.MaxValue && newDistance < distances[neighbor])
                    {
                        distances[neighbor] = newDistance;
                        pq.Enqueue(neighbor, newDistance);
                    }
                }
            }

            return distances;
        }
    }
}
