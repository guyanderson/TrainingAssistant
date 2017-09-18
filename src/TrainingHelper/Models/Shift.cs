using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{
    [Table("Shifts")]
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int FabId { get; set; }

        public virtual Fab Fab { get; set; }
        public virtual ICollection<OperatorCertifications> Operator { get; set; }

        public Shift() { }

        public Shift(string name)
        {
            Name = name;
            FabId = 1;
        }
    }
}
