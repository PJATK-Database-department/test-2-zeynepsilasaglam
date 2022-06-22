using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    [Table("Car")]
    public class Car
    {
        [Key]
        public int IdCar { get; set; }
        [Required, MaxLength(20, ErrorMessage = "MAx Length is 20")]
        public string Name { get; set; }
        public int ProductionYear { get; set; }

        public ICollection<Inspection> Inspections { get; set; } = new HashSet<Inspection>();
    }
}
