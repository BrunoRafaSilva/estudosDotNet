using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identifyOs.Interfaces
{
    public interface IDynamicLinkTemplate
    {
        public String TemplateName { get; set; }
        public String TemplateVersion { get; set; }
        public String ClientNumber { get; set; }
    }
    
}