namespace KT_7
{
    public class FlightEdge
    {
        public int Target { get; set; }
        public int Cost { get; set; }
        public int BatteryCost { get; set; }

        public FlightEdge(int target, int cost, int batteryCost)
        {
            Target = target;
            Cost = cost;
            BatteryCost = batteryCost;
        }
    }
}
