﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingHelper.Models;

namespace TrainingHelper.ViewModels
{
    public class BayDetailVM
    {
        public Bay Bay;

        public BayDetailVM(Bay bay)
        {
            Bay = bay;
        }

    }
}
