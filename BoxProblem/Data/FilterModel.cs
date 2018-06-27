using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxProblem.Data
{
    public class FilterModel
    {
        public int? MinWeight { get; set; }
        public int? MaxWeight { get; set; }

        public int? MinVolume { get; set; }
        public int? MaxVolume { get; set; }

        public bool? CanHoldLiquid { get; set; }
        public bool? CantHoldLiquid { get; set; }
        public bool? DoesntMatter { get; set; }

        public int? MinCost { get; set; }
        public int? MaxCost { get; set; }
    }
}
