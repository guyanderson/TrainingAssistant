using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{
    [Table("Areas")]
    public class Area
    {
        [Key]
        public int AreaId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int FabId { get; set; }

        public virtual Fab Fab { get; set; }
        public virtual ICollection<Bay> Bay { get; set; }

        public override bool Equals(Object otherArea)
        {
            if (!(otherArea is Area))
            {
                return false;
            }
            else
            {
                Area newArea = (Area)otherArea;
                return this.AreaId.Equals(newArea.AreaId);
            }
        }

        public override int GetHashCode()
        {
            return this.AreaId.GetHashCode();
        }

        public Area() { }

        public Area(string name)
        {
            Name = name;
            FabId = 1;
        }
    }
}
 