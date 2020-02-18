using System.Collections.Generic;

namespace PathFinderAlgorithm
{
    public interface IPathFinder
    {
        void CheckNode(Queue queue, IEnumerable<Route> routes, IDictionary<Node, CheckPoint> checkPoints);
    }
}