namespace RealEstate_with_efcore.Models
{
    public class House
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public string FlatFloor { get; set; }
        public string Area { get; set; }
        public Company Company { get; set; }
        public Broker Broker { get; set; }

        //public int? CompanyId { get; set; }
        //public string CompanyName { get; set; }
        //public string BrokerIdentity { get; set; }
    }
}
