using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PathFinderAlgorithm
{
    public static class UserInterface
    {
        public static void PrintOverview(IDictionary<string, Node> vertices, IEnumerable<Route> routes)
        {
            Console.WriteLine("Nodes:");
            foreach (var node in vertices.Values) Console.WriteLine("\t" + node.Name);

            Console.WriteLine("\nRoutes:");
            foreach (var route in routes)
                Console.WriteLine("\t" + route.From + " -> " + route.To + " Distance: " + route.Distance);
        }

        public static (string, string) GetStartAndEnd()
        {
            Console.WriteLine("\nEnter the start node: ");
            var startNode = Console.ReadLine();
            Console.WriteLine("Enter the destination node: ");
            var destNode = Console.ReadLine();
            return (startNode, destNode);
        }

        public static void PrintShortestPath(string startNode, string destNode, IDictionary<string, Node> vertices,
            IDictionary<Node, CheckPoint> checkPoints)
        {
            var pathList = new List<string> {destNode};

            var currentNode = vertices[destNode];
            while (currentNode != vertices[startNode])
            {
                pathList.Add(checkPoints[currentNode].PreviousNode.Name);
                currentNode = checkPoints[currentNode].PreviousNode;
            }

            pathList.Reverse();
            for (var i = 0; i < pathList.Count; i++)
                Console.Write(pathList[i] + (i < pathList.Count - 1 ? " -> " : "\n"));
            Console.WriteLine("Overall distance: " + checkPoints[vertices[destNode]].PathLength);
        }

        public static void InitGraph(string graphFilePath, IDictionary<string, Node> vertices,
            ICollection<Route> routes, IDictionary<Node, CheckPoint> checkPoints)
        {
            var projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.FullName;
            if (projectDirectory != null && !File.Exists(projectDirectory + Path.DirectorySeparatorChar + graphFilePath)
            )
                throw new FileNotFoundException(
                    $"File {projectDirectory + Path.DirectorySeparatorChar + graphFilePath} not found");

            using var fileStream = File.OpenRead(projectDirectory + Path.DirectorySeparatorChar + graphFilePath);
            using var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128);

            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                var values = line.Split(",");
                var (from, to, distance) = (values[0], values[1], double.Parse(values[2]));

                if (!vertices.ContainsKey(from))
                {
                    vertices.Add(from, new Node(from));
                    checkPoints.Add(vertices[from], new CheckPoint());
                }

                if (!vertices.ContainsKey(to))
                {
                    vertices.Add(to, new Node(to));
                    checkPoints.Add(vertices[to], new CheckPoint());
                }

                routes.Add(new Route(vertices[from], vertices[to], distance));
            }
        }
    }
}