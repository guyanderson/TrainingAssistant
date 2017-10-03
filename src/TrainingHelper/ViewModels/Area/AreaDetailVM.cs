using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class AreaDetailVM
    {
        public virtual Area Area { get; set; }


        public AreaDetailVM(Area area)
        {
            Area = area;
        }
    }
}
