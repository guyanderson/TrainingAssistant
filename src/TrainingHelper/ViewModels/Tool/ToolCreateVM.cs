using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class ToolCreateVM
    {

        public virtual Tool Tool { get; set; }
        public virtual ICollection<Bay> Bay { get; set; }
        public virtual ICollection<Certification> Certification { get; set; }

        public ToolCreateVM(Tool tool, List<Bay> bay, List<Certification> certification)
        {
            Tool = tool;
            Bay = bay;
            Certification = certification;
        }

    }
}
