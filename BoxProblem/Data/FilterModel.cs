using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxProblem.Data
{
    public class FilterModel
    {
        public double MinWeight { get; set; }
        public double MaxWeight { get; set; }

        public double MinVolume { get; set; }
        public double MaxVolume { get; set; }

        public bool CanHoldLiquid { get; set; }
        public bool CantHoldLiquid { get; set; }
        public bool DoesntMatter { get; set; }

        public double MinCost { get; set; }
        public double MaxCost { get; set; }
    }
}
