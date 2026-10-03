using System;

namespace KT_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("КТ-7");
            Console.WriteLine();

            PrintExplanations();
            Console.WriteLine();

            RunTests();

            Console.WriteLine();
            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void PrintExplanations()
        {
            Console.WriteLine("Письменное обоснование логики и алгоритма поиска:");
            Console.WriteLine();
            Console.WriteLine("1. Что представляет собой одно состояние поиска:");
            Console.WriteLine("Одно состояние поиска описывается парой из текущей вершины графа и остатка заряда батареи в этой вершине. В отличие от стандартного алгоритма Дейкстры, где вершина посещается один раз с минимальной стоимостью, в данной задаче одна и та же вершина может быть достигнута с разным уровнем заряда батареи и разной стоимостью. Именно пара (вершина, заряд) выступает уникальным состоянием.");
            Console.WriteLine();
            Console.WriteLine("2. Почему обычный алгоритм Дейкстры по вершинам дал бы неверный результат:");
            Console.WriteLine("Обычный алгоритм Дейкстры сохраняет только минимальную стоимость достижения вершины и отбрасывает альтернативные пути. Рассмотрим пример, где путь А имеет меньшую стоимость до вершины, но оставляет малый остаток заряда, достаточный только для остановки, в то время как путь Б имеет большую стоимость, но сохраняет полный заряд благодаря посещению зарядной станции. Если обычный Дейкстра оставит только путь А, дрон не сможет продолжить полет из-за разряда батареи. Путь Б с большей стоимостью является единственным жизнеспособным и оптимальным маршрутом, но Дейкстра по вершинам потерял бы его.");
            Console.WriteLine();
            Console.WriteLine("3. Почему выбранная структура хранения минимальной стоимости по состояниям достаточна и не приводит к потере оптимального маршрута:");
            Console.WriteLine("Двумерная таблица минимальных стоимостей minCost[vertex, battery] хранит минимальную стоимость для каждого сочетания вершины и конкретного уровня заряда батареи. Поскольку емкость батареи ограничена фиксированным максимальным значением, количество состояний конечно. Приоритетная очередь извлекает состояние с наименьшей стоимостью. Если мы приходим в вершину с тем же зарядом, но большей стоимостью, такое состояние отсекается. Это гарантирует нахождение оптимального решения без пропуска жизнеспособных путей.");
        }

        private static void RunTests()
        {
            Console.WriteLine("Демонстрация и тесты алгоритма маршрутизации дрона:");
            Console.WriteLine();

            Graph graph = new Graph(5);
            graph.AddEdge(0, 1, 10, 60);
            graph.AddEdge(0, 2, 5, 40);
            graph.AddEdge(2, 1, 5, 30);
            graph.AddEdge(1, 3, 10, 50);
            graph.AddEdge(2, 3, 20, 70);
            graph.AddEdge(3, 4, 5, 20);

            graph.SetChargingStation(2, true);

            int start = 0;
            int destination = 4;
            int batteryCapacity = 100;

            int result1 = DroneRouter.MinCostRoute(graph, start, destination, batteryCapacity);
            Console.WriteLine($"Тест 1 (старт: {start}, финиш: {destination}, батарея: {batteryCapacity}, станция в вершине 2)");
            Console.WriteLine($"Ожидаемый результат: 25");
            Console.WriteLine($"Полученный результат: {result1}");
            Console.WriteLine();

            int smallBattery = 35;
            int result2 = DroneRouter.MinCostRoute(graph, start, destination, smallBattery);
            Console.WriteLine($"Тест 2 (старт: {start}, финиш: {destination}, малая батарея: {smallBattery})");
            Console.WriteLine($"Ожидаемый результат: -1");
            Console.WriteLine($"Полученный результат: {result2}");
        }
    }
}
