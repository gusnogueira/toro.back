namespace toro.Data.Entities
{
    public class Investment
    {
        public string Ticker { get; set; }
        public int Amount { get; set; }
        public double CurrentPrice { get; set; }
        public double AverageCost { get; set; }
        public double Result { get; set; }
        public double TotalCost { get; set; }
    }
}
