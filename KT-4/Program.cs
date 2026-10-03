using System;
using System.Collections.Generic;

namespace KT_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("КТ-4");
            Console.WriteLine();

            Graph graph = new Graph();
            graph.AddEdge(0, 1, 4);
            graph.AddEdge(0, 2, 1);
            graph.AddEdge(2, 1, 2);
            graph.AddEdge(1, 3, 5);
            graph.AddEdge(3, 4, 1);
            graph.AddVertex(5);

            Console.WriteLine("Часть 1: Обходы графа и компоненты связности");
            PrintList("DFS из вершины 0:", graph.Dfs(0));
            PrintList("BFS из вершины 0:", graph.Bfs(0));
            
            int components = graph.CountConnectedComponents();
            Console.WriteLine($"Количество компонент связности: {components}");
            Console.WriteLine();

            Console.WriteLine("Часть 2: Поиск цикла");
            bool hasCycleBefore = graph.HasCycle();
            Console.WriteLine($"Наличие цикла до удаления ребра (2-1): {hasCycleBefore}");

            graph.RemoveEdge(2, 1);
            bool hasCycleAfter = graph.HasCycle();
            Console.WriteLine($"Наличие цикла после удаления ребра (2-1): {hasCycleAfter}");
            Console.WriteLine();

            Console.WriteLine("Часть 3: Алгоритм Дейкстры");
            Graph dijkstraGraph = new Graph();
            dijkstraGraph.AddEdge(0, 1, 4);
            dijkstraGraph.AddEdge(0, 2, 1);
            dijkstraGraph.AddEdge(2, 1, 2);
            dijkstraGraph.AddEdge(1, 3, 5);
            dijkstraGraph.AddEdge(3, 4, 1);
            dijkstraGraph.AddVertex(5);

            Dictionary<int, int> distances = dijkstraGraph.Dijkstra(0);
            foreach (KeyValuePair<int, int> kvp in distances)
            {
                string distStr = kvp.Value == int.MaxValue ? "бесконечность" : kvp.Value.ToString();
                Console.WriteLine($"Расстояние до вершины {kvp.Key}: {distStr}");
            }

            Console.WriteLine();
            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void PrintList(string title, List<int> list)
        {
            Console.Write($"{title} ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine();
        }
    }
}
