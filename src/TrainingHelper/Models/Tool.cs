using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHelper.Models
{
    [Table("Tools")]
    public class Tool
    {
        [Key]
        public int ToolId { get; set; }
        public string Name { get; set; }
        public int BayId { get; set; }
        public virtual ICollection<Shift> Shift { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<Bay> Bay { get; set; }
        public virtual ICollection<Certification> Certification { get; set; }
        public virtual ICollection<Operator> Operator { get; set; }

        public Tool() { }

        public Tool(string name, int bayId)
        {
            Name = name;
            BayId = bayId;
        }
    }
}
