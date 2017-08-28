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
        public int AreaId { get; set; }
        public virtual ICollection<Shift> Shift { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<Tool> Tool { get; set; }
        public virtual ICollection<Certification> Certification { get; set; }
        public virtual ICollection<Operator> Operator { get; set; }

        public Bay() { }

        public Bay(string name, int areaId)
        {
            Name = name;
            AreaId = areaId;
        }

    }
}



