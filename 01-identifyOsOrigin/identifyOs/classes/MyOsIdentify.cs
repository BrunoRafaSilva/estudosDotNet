using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//  https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Sec-CH-UA-Platform

namespace identifyOs.classes
{
    public class MyOsIdentify
    {
        private string _osSystem { get; set; }
        public string StoreLink { get; private set; }
        public string ClientOs { get; private set; }

        private const string _DEFAULTSTORELINK = "https://www.chevrolet.com.br/";

        public MyOsIdentify(HttpContext httpContext)
        {
            _osSystem = string.Empty;
            try
            {
                _osSystem = httpContext.Request.Headers["sec-ch-ua-platform"].ToString().Trim('"').ToUpper();
                
                if(string.IsNullOrEmpty(_osSystem)){
                    _osSystem = httpContext.Request.Headers["user-agent"].ToString().ToUpper();
                }
            }
            catch (System.Exception)
            {
                StoreLink = _DEFAULTSTORELINK;
                ClientOs = "Unknown";
                return;
            }

            switch (_osSystem)
            {
                case "ANDROID":
                    StoreLink = "https://play.google.com/store/apps/details?id=com.gm.chevrolet.nomad.ownership&hl=pt_BR";
                    ClientOs = "Android";
                    break;

                case "CHROME OS":
                    StoreLink = "https://play.google.com/store/apps/details?id=com.gm.chevrolet.nomad.ownership&hl=pt_BR";
                    ClientOs = "CHROME OS";
                    break;

                case "CHROMIUM OS":
                    StoreLink = "https://play.google.com/store/apps/details?id=com.gm.chevrolet.nomad.ownership&hl=pt_BR";
                    ClientOs = "CHROMIUM OS";
                    break;

                case "IOS":
                    StoreLink = "https://apps.apple.com/br/app/mychevrolet/id398596699";
                    ClientOs = "iOS";
                    break;

                case "LINUX":
                    StoreLink = _DEFAULTSTORELINK;
                    ClientOs = "Linux";
                    break;

                case "MACOS":
                    StoreLink = _DEFAULTSTORELINK;
                    ClientOs = "MacOS";
                    break;

                case "WINDOWS":
                    StoreLink = _DEFAULTSTORELINK;
                    ClientOs = "Windows";
                    break;

                default:
                    StoreLink = _DEFAULTSTORELINK;
                    ClientOs = _osSystem;
                    break;
            }

        }
    }
}