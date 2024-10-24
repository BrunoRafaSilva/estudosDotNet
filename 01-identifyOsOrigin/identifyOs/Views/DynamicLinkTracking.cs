using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identifyOs.Interfaces;

namespace identifyOs.Views
{
    public class DynamicLinkTracking: IDynamicLinkTracking
    {
        required public string TemplateName { get; set; }
        required public string TemplateVersion { get; set; }
        required public string ClientNumber { get; set; }
    }
}