using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcAppMaster.Models
{
    public class HoursPrice
    {
        [Key]
        public int HpId { get; set; }
        public string HpTypePc { get; set; }
        public double HpSinglePrice { get; set; }
        public double HpMultiPrice { get; set; }
    }
}
