using System.Collections.Generic;
using System.Linq;

namespace PathFinderAlgorithm
{
    public class Dijkstra : IPathFinder
    {
        public void CheckNode(PrioQueue queue, IEnumerable<Route> routes, IDictionary<Node, CheckPoint> checkPoints)
        {
            if (queue.Count == 0)
                return;

            var routeList = routes.ToList();
            foreach (var route in routeList.ToList().FindAll(r => r.From == queue.First.Value))
            {
                if (checkPoints[route.To].Status == CheckPointStatus.Permanent)
                    continue;

                var travelledDistance = checkPoints[queue.First.Value].PathLength + route.Distance;

                if (travelledDistance < checkPoints[route.To].PathLength)
                {
                    checkPoints[route.To].Update(travelledDistance, queue.First.Value);
                }

                if (!queue.HasNode(route.To))
                {
                    queue.AddNodeWithPriority(route.To, checkPoints);
                }
            }
            
            checkPoints[queue.First.Value].Confirm();
            queue.RemoveFirst();
            
            CheckNode(queue, routeList, checkPoints);
        }
    }
}