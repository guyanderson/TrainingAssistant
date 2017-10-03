using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{

    [Table("Operators")]
    public class Oper
    {
        [Key]
        public int OperatorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ShiftId { get; set; }
        public byte[] Img { get; set; }

        public virtual Shift Shift { get; set; }
        public virtual ICollection<OperatorCertifications> OperatorCertifications { get; set; }

        public Oper() { }

        public Oper(string name, int shiftId)
        {
            Name = name;
            ShiftId = shiftId;
        }

        public Oper(string name, int shiftId, byte[] img)
        {
            Name = name;
            ShiftId = shiftId;
            Img = img;
        }
    }
}
