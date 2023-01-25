using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcAppMaster.Models.ViewModel
{
    public class DrinkReceiptForDrinksViewModel
    {
     
        public int RfDrinkId { get; set; }
        public Guid BillId { get; set; }
        public string RfDrink { get; set; }
        public int RfDrinkQut { get; set; }
        public int RfDrinkprice { get; set; }
        public int RfDrinkTotal { get; set; }
        public int DrinkId { get; set; }
        public List<Drinks> Drinks { get; set; }
    }
}
