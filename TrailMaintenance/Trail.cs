namespace TrailMaintenance
{
    public class Trail
    {
        public Trail(Node startNode, Node endNode, int weight)
        {
            Start = startNode;
            End = endNode;
            Weight = weight;
        }
        public Node Start { get; set; }
        public Node End { get; set; }
        public int Weight { get; set; }
    }
}