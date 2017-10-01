using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class AreaIndexVM
    {
        public List<Area> Areas { get; set; }
        public List<Area> FailedAreaList { get; set; }

        public AreaIndexVM(List<Area> areas, List<Area> failedAreaList)
        {
            Areas = areas;
            FailedAreaList = failedAreaList;
        }
    }
}
