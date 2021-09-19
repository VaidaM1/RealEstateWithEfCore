using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_with_efcore.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }

        [NotMapped]
        public List<Broker> Brokers { get; set; }
        [NotMapped]
        public List<int> BrokerIds { get; set; }

        public List<CompanyBroker> CompanyBrokers { get; set; }
    }
}
