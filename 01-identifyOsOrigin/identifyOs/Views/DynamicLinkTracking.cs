using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identifyOs.Database.Models;
using identifyOs.Interfaces;
using Supabase;

namespace identifyOs.Views
{
    public class DynamicLinkTracking : IDynamicLinkTracking
    {
        public string TemplateName { get; set; }
        public string TemplateVersion { get; set; }
        public string ClientNumber { get; set; }
        public string StoreLink { get; set; }

        public DynamicLinkTracking( string templateName, string templateVersion, string clientNumber, string storeLink)
        {
            TemplateName = templateName;
            TemplateVersion = templateVersion;
            ClientNumber = clientNumber;
            StoreLink = storeLink;

            var retorno = InsertRecord();
        }

        public async Task<string> InsertRecord()
        {


            return "sexo";
        }
    }
}