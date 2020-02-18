namespace PathFinderAlgorithm
{
    public class Route
    {
        public Route(Node from, Node to, double distance)
        {
            From = from;
            To = to;
            Distance = distance;
        }

        public Node From { get; }
        public Node To { get; }
        public double Distance { get; }
    }
}