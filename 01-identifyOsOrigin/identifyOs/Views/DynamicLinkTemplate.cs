using identifyOs.Interfaces;
using Newtonsoft.Json;

namespace identifyOs.Views
{
    public class DynamicLinkTemplate : IDynamicLinkTemplate
    {
        public String TemplateName { get; set; }
        public String TemplateVersion { get; set; }
        public String ClientNumber { get; set; }

        // Campo privado para StoreLink
        private String _storeLink { get; set; }

        public DynamicLinkTemplate(String templateName, String templateVersion, String clientNumber, String storeLink)
        {
            TemplateName = templateName;
            TemplateVersion = templateVersion;
            ClientNumber = clientNumber;
            _storeLink = storeLink;
        }

        public Object GetResult()
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