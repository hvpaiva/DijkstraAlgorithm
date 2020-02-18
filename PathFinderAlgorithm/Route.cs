namespace PathFinderAlgorithm
{
    public class Route
    {
        public Node From { get; }
        public Node To { get; }
        public double Distance { get; }

        public Route(Node @from, Node to, double distance)
        {
            From = @from;
            To = to;
            Distance = distance;
        }
    }
}