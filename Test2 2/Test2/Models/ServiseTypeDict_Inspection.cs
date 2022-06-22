using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    [Table("ServiseTypeDict_Inspection")]
    public class ServiseTypeDict_Inspection
    {
        public int IdServiceType { get; set; }
        [ForeignKey("IdServiceType")]
        public ServiceTypeDict ServiceTypeDict { get; set; }

        public int IdInspection { get; set; }
        [ForeignKey("IdInspection")]
        public Inspection Inspection { get; set; }
        [MaxLength(300, ErrorMessage = "Max Length is 300")]
        public string Comments { get; set; }
    }
}
