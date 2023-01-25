using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace PcAppMaster.Models
{
    public class Receipt
    {
        [Key]
        public Guid BillId { get; set; }
        public string RecPcName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime RecReceiptDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public DateTime RecStartTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        public DateTime RecEndTime { get; set; }
        public double RecTotalMinutes { get; set; }
        public bool RecHoursType { get; set; }
        public double RecHoursPrice { get; set; }
        public double RecDrinkPrice { get; set; }
        public ReceiptForDrinks ReceiptForDrinks { get; set; }
        public List<ReceiptForDrinks> RfDrinkId { get; set; }
        public double RecTotal { get; set; }
    }
}
