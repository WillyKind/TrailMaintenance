namespace TrailMaintenance
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public bool IsVisited { get; set; }
    }
}