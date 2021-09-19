using RealEstate_with_efcore.Models;
using System.Collections.Generic;

namespace RealEstate_with_efcore.Dtos
{
    public class CreateBroker
    {
        //public string Name { get; set; }
        //public string Surname { get; set; }
        public List<Company> Companies { get; set; }
        public List<int> CompanyIds { get; set; }
        public Broker Broker { get; set; }
        public string CompanyBrokers { get; set; }
    }
}
