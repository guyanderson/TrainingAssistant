using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{
    [Table("Fab")]
    public class Fab
    {
        [Key]
        public int FabId { get; set; }
        
        public Shift Shift { get; set; }

        public Area Area { get; set; }

        public Bay Bay { get; set; }

        public Tool Tool { get; set; }

        public Operator Operator { get; set; }

        public Certification Certification { get; set; }

        //public virtual ICollection<Area> Area { get; set; }

        public Fab() { }
    }
}
 