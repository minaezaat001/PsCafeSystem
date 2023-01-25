using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcAppMaster.Models
{
    public class Drinks
    {
        [Key]
        public int DrDrinkId { get; set; }
        public string DrDrinkName { get; set; }
        public int DrDrinkPrice { get; set; }
        public int DrDrinkQut { get; set; }
    }
}
