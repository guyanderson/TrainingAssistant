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
        public List<Certification> FailedCertList { get; set; }

        public AreaIndexVM(List<Area> areas, List<Area> failedAreaList, List<Certification> failedCertList)
        {
            Areas = areas;
            FailedAreaList = failedAreaList;
            FailedCertList = failedCertList;
        }
    }
}
