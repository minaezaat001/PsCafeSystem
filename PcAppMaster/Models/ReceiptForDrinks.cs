using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcAppMaster.Models
{
    public class ReceiptForDrinks
    {
        [Key]
        public int RfDrinkId { get; set; }
        public Guid BillId { get; set; }
        public string RfDrink{ get; set; }
        public int RfDrinkQut { get; set; }
        public int RfDrinkprice { get; set; }
        public int RfDrinkTotal { get; set; }
        public Drinks drinks { get; set; }

    }
}
