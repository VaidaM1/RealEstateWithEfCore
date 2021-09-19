using RealEstate_with_efcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_with_efcore.Dtos
{
    public class HouseIndex
    {
        public House House { get; set; }
        //public Company Company { get; set; }
        //public Broker Broker { get; set; }
        public List<House> Houses { get; set; }
    }
}
