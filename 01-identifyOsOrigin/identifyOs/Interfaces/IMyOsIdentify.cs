using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identifyOs.Interfaces
{
    public interface IMyOsIdentify
    {
        HttpContext HttpContexto { get; set; }
    }
}