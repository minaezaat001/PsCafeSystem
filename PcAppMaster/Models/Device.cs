using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcAppMaster.Models
{
    public class Device
    {
        [Key]
        public int Dvid { get; set; }
        public string DvNumber { get; set; }
        [ForeignKey ("HoursPrice")]
        public int HpId { get; set; }
        public HoursPrice  HoursPrice { get; set; }


    }
}
