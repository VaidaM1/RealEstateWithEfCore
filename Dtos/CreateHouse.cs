using RealEstate_with_efcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_with_efcore.Dtos
{
    public class CreateHouse
    {
        public House House { get; set; }
        public List<Company> Companies { get; set; }
        public List<Broker> Brokers { get; set; }
    }
}
