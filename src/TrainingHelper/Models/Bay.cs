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
        public string Name { get; set; }
        public int TargetTrained { get; set; }
        public int AreaId { get; set; }

        public virtual ICollection<Area> Area { get; set; }

        public Bay() { }

        public Bay(string name, int target, int areaId)
        {
            Name = name;
            TargetTrained = target;
            AreaId = areaId;
        }

    }
}



