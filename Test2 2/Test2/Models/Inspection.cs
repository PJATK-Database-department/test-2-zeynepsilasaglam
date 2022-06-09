using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    [Table("Inspection")]
    public class Inspection
    {
        [Key]
        public int IdInspection { get; set; }
        public int IdCar { get; set; }
        [ForeignKey("IdCar")]
        public Car Car { get; set; }

        public int IdMechanic { get; set; }
        [ForeignKey("IdMechanic")]
        public Mechanic Mechanic { get; set; }
        [Required]
        public DateTime InspectionDate { get; set; }
        [MaxLength(300, ErrorMessage = "Max Length is 300")]
        public string Comment { get; set; }

        public ICollection<ServiseTypeDict_Inspection> ServiseTypeDict_Inspections { get; set; } = new HashSet<ServiseTypeDict_Inspection>();
    }
}
