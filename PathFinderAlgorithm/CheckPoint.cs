namespace PathFinderAlgorithm
{
    public class CheckPoint
    {
        public CheckPoint()
        {
            Status = CheckPointStatus.Temporary;
            PathLength = double.PositiveInfinity;
            PreviousNode = null;
        }

        public double PathLength { get; private set; }
        public Node PreviousNode { get; private set; }
        public CheckPointStatus Status { get; private set; }

        public void Update(double pathLength, Node previousNode)
        {
            PathLength = pathLength;
            PreviousNode = previousNode;
        }

        public void Confirm()
        {
            Status = CheckPointStatus.Permanent;
        }

        public void SetStartingPoint()
        {
            PathLength = 0;
        }
    }
}