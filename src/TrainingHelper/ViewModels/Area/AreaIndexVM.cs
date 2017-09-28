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

        public AreaIndexVM( List<Area> areas)
        {
            Areas = areas;
        }
    }
}
