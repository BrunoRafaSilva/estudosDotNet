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
        [HttpGet("myos")]
        public IActionResult GetMyOs()
        {
            var clientOs = new MyOsIdentify(HttpContext);
            return Ok(clientOs);
        }

        [HttpGet("redirecttoapp")]
        public IActionResult RedirectToApp()
        {
            var clientOs = new MyOsIdentify(HttpContext);
            return Redirect(clientOs.StoreLink);
        }

        [HttpPost("generatedynamiclinktracking")]
        public IActionResult GenerateDynamicLinkTracking([FromBody] DynamicLinkTracking request)
        {
            var reponse = new DynamicLinkTracking
            {
                TemplateName = request.TemplateName,
                TemplateVersion = request.TemplateName,
                ClientNumber = request.TemplateName,
            };

            return Ok(reponse);
        }
    }
}