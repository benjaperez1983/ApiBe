namespace DomainModel.Entities
{ 
    public class PricesDetail
    {
        public int Id { get; set; }
        public int? date { get; set; }
        public double? open { get; set; }
        public double? high { get; set; }
        public double? low { get; set; }
        public double? close { get; set; }
        public int? volume { get; set; }
        public double? adjclose { get; set; }
        public double? amount { get; set; }
        public string? type { get; set; }
        public double? data { get; set; }
    }
}
