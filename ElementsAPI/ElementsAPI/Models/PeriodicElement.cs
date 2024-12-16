namespace ElementsAPI.Models
{
    public class PeriodicElement
    {
        public int Position { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Weight { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public bool IsArchived { get; set; } = false;
    }
}
