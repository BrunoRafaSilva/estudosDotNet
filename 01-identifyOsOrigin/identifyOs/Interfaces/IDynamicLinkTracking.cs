using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identifyOs.Interfaces
{
    public interface IDynamicLinkTracking
    {
        public string TemplateName { get; set; }
        public string TemplateVersion { get; set; }
        public string ClientNumber { get; set; }
        public string StoreLink { get; set; }
    }
    
}