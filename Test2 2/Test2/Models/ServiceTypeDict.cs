using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    [Table("ServiceTypeDict")]
    public class ServiceTypeDict
    {
        [Key]
        public int IdServiceType { get; set; }
        [Required, MaxLength(20, ErrorMessage ="MAx Lenght is 20")]
        public string ServiceType { get; set; }
        [Required]
        public float Price { get; set; }
        public ICollection<ServiseTypeDict_Inspection> ServiseTypeDict_Inspections { get; set; } = new HashSet<ServiseTypeDict_Inspection>();
    }
}
