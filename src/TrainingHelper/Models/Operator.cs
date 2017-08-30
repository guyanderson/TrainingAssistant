using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{

    [Table("Operators")]
    public class Operator
    {
        [Key]
        public int OperatorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ShiftId { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual ICollection<OperatorCertification> OperatorCertification { get; set; }

        public Operator() { }

        public Operator(string name, int shiftId)
        {
            Name = name;
            ShiftId = shiftId;
        }
    }

}
