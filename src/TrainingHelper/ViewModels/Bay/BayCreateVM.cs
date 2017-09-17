using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class BayCreateVM
    {
        public virtual Bay Bay { get; set; }
        public virtual ICollection<Area> Area { get; set; }

        public BayCreateVM(Bay bay, List<Area> area)
        {
            Bay = bay;
            Area = area;
        }

    }
}
