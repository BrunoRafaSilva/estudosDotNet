using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identifyOs.Interfaces;
using identifyOs.Views;
using Microsoft.AspNetCore.Mvc;


namespace identifyOs.Controller
{
    [ApiController]
    [Route("/[controller]")]
    public class ApiController : ControllerBase
    {

        [HttpGet("redirecttoapp")]
        public IActionResult RedirectToApp()
        {
            var clientOs = new MyOsIdentify(HttpContext);
            return Redirect(clientOs.OsSystem);
        }

        // colocar DynamicLinkTracking faz com que ele seja o modelo de entrada
        [HttpPost("dynamiclinkbytemplate")]
        public IActionResult GenerateDynamicLinkTracking([FromBody] DynamicLinkTemplate request)
        {
            var clientOs = new MyOsIdentify(HttpContext);
            var response = new DynamicLinkTemplate(request.TemplateName, request.TemplateVersion, request.ClientNumber, clientOs.OsSystem).GetResult();
            return Ok(response);
        }

        [HttpGet("dynamiclinkbyparams")]
        public IActionResult GenerateDynamicLinkParams([FromQuery] DynamicLinkParams request)
        {
            var clientOs = new MyOsIdentify(HttpContext);
            var response = new DynamicLinkParams(request.TrackingCategory, request.TrackingAction, request.PlayStore, request.AppStore, request.Alternative, request.RouterAuthorization).GetLink(clientOs.OsSystem);
            return Redirect(response);

        }

    }
}