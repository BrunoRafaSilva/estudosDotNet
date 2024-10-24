using identifyOs.Interfaces;
using Newtonsoft.Json;

namespace identifyOs.Views
{
    public class DynamicLinkTemplate : IDynamicLinkTemplate
    {
        public string TemplateName { get; set; }
        public string TemplateVersion { get; set; }
        public string ClientNumber { get; set; }

        // Campo privado para StoreLink
        private string _storeLink { get; set; }

        public DynamicLinkTemplate(string templateName, string templateVersion, string clientNumber, string storeLink)
        {
            TemplateName = templateName;
            TemplateVersion = templateVersion;
            ClientNumber = clientNumber;
            _storeLink = storeLink;
        }

        public object GetResult()
        {
            var result = new
            {
                TemplateName,
                TemplateVersion,
                ClientNumber,
                StoreLink = _storeLink
            };
            return result;
        }
    }
}