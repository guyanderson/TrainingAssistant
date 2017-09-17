using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class BayDetailVM
    {
        public virtual Bay Bay { get; set; }
        public virtual ICollection<Tool> Tool { get; set; }

        public BayDetailVM(Bay bay, List<Tool> tools)
        {
            Bay = bay;
            Tool = tools;
        }

    }
}
