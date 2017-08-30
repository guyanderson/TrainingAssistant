using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{
    [Table("Bays")]
    public class Bay
    {
        [Key]
        public int BayId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TargetTrained { get; set; }
        [Required]
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<Tool> Tool { get; set; }

        public Bay() { }

        public Bay(string name, int target, int areaId)
        {
            Name = name;
            TargetTrained = target;
            AreaId = areaId;
        }

    }
}



