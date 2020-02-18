using System.Collections.Generic;

namespace PathFinderAlgorithm
{
    public class Queue : LinkedList<Node>
    {
        public void AddNodeWithPriority(Node node, IDictionary<Node, CheckPoint> checkPoints)
        {
            if (Count == 0)
            {
                AddFirst(node);
            }
            else
            {
                if (checkPoints[node].PathLength > checkPoints[Last.Value].PathLength)
                    AddLast(node);
                else
                    for (var it = First; it != null; it = it.Next)
                    {
                        if (!(checkPoints[node].PathLength <= checkPoints[it.Value].PathLength)) continue;
                        AddBefore(it, node);
                        break;
                    }
            }
        }

        public bool HasNode(Node node)
        {
            for (var it = First; it != null; it = it.Next)
                if (it.Value.Equals(node))
                    return true;
            return false;
        }
    }
}