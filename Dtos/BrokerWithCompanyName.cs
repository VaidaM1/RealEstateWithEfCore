﻿using RealEstate_with_efcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate_with_efcore.Dtos
{
    public class BrokerWithCompanyName
    {
        public Broker Broker { get; set; }
        public string CompaniesNames { get; set; }
}
}
