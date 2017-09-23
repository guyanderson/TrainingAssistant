using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class ToolIndexVM
    {
        public List<Tool> Tool { get; set; }

        public ToolIndexVM(List<Tool> tool)
        {
            Tool = tool;
        }
    }
}
