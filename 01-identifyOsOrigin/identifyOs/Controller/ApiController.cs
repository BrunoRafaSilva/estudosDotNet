using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identifyOs.Database.Models;
using identifyOs.Interfaces;
using identifyOs.Views;
using Microsoft.AspNetCore.Mvc;
using Supabase;

namespace identifyOs.Controller
{
    [ApiController]
    [Route("/[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly Client _supabaseClient;
        public ApiController(Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        [HttpGet("redirecttoapp")]
        public IActionResult RedirectToApp()
        {
            var clientOs = new MyOsIdentify(HttpContext);
            return Redirect(clientOs.StoreLink);
        }

        // colocar DynamicLinkTracking faz com que ele seja o modelo de entrada
        [HttpPost("generatedynamiclinktracking")]
        public IActionResult GenerateDynamicLinkTracking([FromBody] DynamicLinkTracking request)
        {
            var clientOs = new MyOsIdentify(HttpContext);
            var response = new DynamicLinkTracking(request.TemplateName, request.TemplateVersion, request.ClientNumber, clientOs.StoreLink);
            return Ok(response);
        }

        [HttpGet("cassino")]
        public async Task<IActionResult> GetOs()
        {
            // Use o _supabaseClient para interagir com o Supabase
            var response = await _supabaseClient.From<TesteTable>().Get();
            return Ok(response.Models);
        }
    }
}