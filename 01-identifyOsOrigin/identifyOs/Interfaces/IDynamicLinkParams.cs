using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identifyOs.Interfaces
{
    public interface IDynamicLinkParams
    {
        public String TrackingCategory { get; set; }
        public String TrackingAction { get; set; }
        public String PlayStore { get; set; }
        public String AppStore { get; set; }
        public String Alternative { get; set; }
        public String RouterAuthorization { get; set; }
    }
}