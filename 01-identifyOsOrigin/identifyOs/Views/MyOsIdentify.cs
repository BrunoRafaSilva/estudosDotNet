using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//  https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Sec-CH-UA-Platform

namespace identifyOs.Views
{
    public class MyOsIdentify
    {
        private string _osSystem { get; set; }
        public string StoreLink { get; private set; }

        private const string _DEFAULTSTORELINK = "https://www.chevrolet.com.br/";

        private const string _DEFAULTCLIENTOS = "Unknown";

        public MyOsIdentify(HttpContext httpContext)
        {
            _osSystem = _DEFAULTCLIENTOS;
            try
            {
                _osSystem = httpContext.Request.Headers["sec-ch-ua-platform"].ToString().Trim('"').ToUpper();

                if (string.IsNullOrEmpty(_osSystem))
                {
                    _osSystem = _DEFAULTCLIENTOS;
                }
            }
            catch (System.Exception)
            {
                StoreLink = _DEFAULTSTORELINK;
                return;
            }

            switch (_osSystem)
            {
                case "ANDROID":
                    StoreLink = "https://play.google.com/store/apps/details?id=com.gm.chevrolet.nomad.ownership&hl=pt_BR";
                    break;

                case "CHROMEOS":
                    StoreLink = "https://play.google.com/store/apps/details?id=com.gm.chevrolet.nomad.ownership&hl=pt_BR";
                    break;

                case "CHROMIUMOS":
                    StoreLink = "https://play.google.com/store/apps/details?id=com.gm.chevrolet.nomad.ownership&hl=pt_BR";
                    break;

                case "IOS":
                    StoreLink = "https://apps.apple.com/br/app/mychevrolet/id398596699";
                    break;

                case "LINUX":
                    StoreLink = _DEFAULTSTORELINK;
                    break;

                case "MACOS":
                    StoreLink = _DEFAULTSTORELINK;
                    break;

                case "WINDOWS":
                    StoreLink = _DEFAULTSTORELINK;
                    break;

                default:
                    StoreLink = _DEFAULTSTORELINK;
                    break;
            }

        }
    }
}