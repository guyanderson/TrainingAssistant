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
        
        public Fab() { }
    }
}
 