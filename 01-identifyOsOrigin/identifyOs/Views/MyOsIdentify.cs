using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identifyOs.Interfaces;

//  https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Sec-CH-UA-Platform

namespace identifyOs.Views
{
    public class MyOsIdentify : IMyOsIdentify
    {
        public HttpContext HttpContexto { get; set; }
        public String OsSystem { get; private set; }
        private String _osSystem { get; set; }
        private const String USERAGENT = "User-Agent";
        private const String SEC_CH_UA_PLATFORM = "Sec-CH-UA-Platform";
        public const String _DEFAULTCLIENTOS = "Unknown";

        private readonly List<String> _osList = ["Android", "iPhone", "iPad", "iOS"];

        public MyOsIdentify(HttpContext HttpContexto)
        {
            _osSystem = ValidatePlataform(HttpContexto);

            var osSystem = _osList.Find(a => _osSystem.ToUpper().Contains(a.ToUpper()));

            if (osSystem == null)
            {
                OsSystem = _osSystem;
                return;
            }

            OsSystem = osSystem;

        }

        static String ValidatePlataform(HttpContext httpContext, String defaultClientOs = _DEFAULTCLIENTOS)
        {
            String clientPlataform;
            if (httpContext.Request.Headers.ContainsKey(SEC_CH_UA_PLATFORM))
            {
                clientPlataform = httpContext.Request.Headers[SEC_CH_UA_PLATFORM].ToString();
            }
            else if (httpContext.Request.Headers.ContainsKey(USERAGENT))
            {
                clientPlataform = httpContext.Request.Headers[USERAGENT].ToString();
            }
            else
            {
                clientPlataform = defaultClientOs;
            }
            return clientPlataform;
        }
    }
}