using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate_with_efcore.Models
{
    public class Broker
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string Name { get; set; }
        [DisplayName("Last Name")]
        public string Surname { get; set; }

        [NotMapped]
        public string FullName { get { return Name + " " + Surname; } }

        [NotMapped]
        public List<Company> Companies { get; set; }
        public List<House> Houses { get; set; }
        public List<CompanyBroker> CompanyBroker { get; set; }

        //public List<int> CompanyId { get; set; }
        [NotMapped]
        public string CompanyName { get; set; }


    }
}
