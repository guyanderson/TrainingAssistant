using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class ToolDetailVM
    {
        public Tool Tool { get; set; }
        public virtual Certification Certification { get; set; }

        public ToolDetailVM(Tool tool, Certification certification)
        {
            Tool = tool;
            Certification = certification;
        }

    }
}
