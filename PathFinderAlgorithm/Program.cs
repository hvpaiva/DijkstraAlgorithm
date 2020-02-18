using System;
using System.Collections.Generic;
using System.IO;

namespace PathFinderAlgorithm
{
    internal static class Program
    {
        private const string GraphFilePath = "graph.txt";
        private static readonly Dictionary<string, Node> Vertices = new Dictionary<string, Node>();
        private static readonly Dictionary<Node, CheckPoint> CheckPoints = new Dictionary<Node, CheckPoint>();
        private static readonly List<Route> Routes = new List<Route>();
        private static readonly IPathFinder PathFinder = new Dijkstra();

        public static void Main()
        {
            try
            {
                UserInterface.InitGraph(GraphFilePath, Vertices, Routes, CheckPoints);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
                return;
            }

            Console.Clear();
            UserInterface.PrintOverview(Vertices, Routes);

            var (startNode, destNode) = UserInterface.GetStartAndEnd();

            CheckPoints[Vertices[startNode]].SetStartingPoint();

            var queue = new Queue();
            queue.AddNodeWithPriority(Vertices[startNode], CheckPoints);

            PathFinder.CheckNode(queue, Routes, CheckPoints);

            UserInterface.PrintShortestPath(startNode, destNode, Vertices, CheckPoints);
        }
    }
}