using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using identifyOs.Interfaces;
using Newtonsoft.Json;

namespace identifyOs.Views
{
    public class DynamicLinkParams : IDynamicLinkParams
    {
        public String TrackingCategory { get; set; }
        public String TrackingAction { get; set; }
        public String PlayStore { get; set; }
        public String AppStore { get; set; }
        public String Alternative { get; set; }
        public String RouterAuthorization { get; set; }
        [JsonIgnore]
        private String _redirectLink { get; set; }

        const String CLICKTRACKING = "https://click-tracking.cs.blip.ai/api/Track";
        public DynamicLinkParams() { }
        public DynamicLinkParams(String trackingCategory, String trackingAction, String playStore, String appStore, String alternative, String routerAuthorization)
        {
            TrackingCategory = HttpUtility.UrlEncode(trackingCategory);
            TrackingAction = trackingAction;
            PlayStore = HttpUtility.UrlEncode(playStore);
            AppStore = HttpUtility.UrlEncode(appStore);
            Alternative = HttpUtility.UrlEncode(alternative);
            RouterAuthorization = HttpUtility.UrlEncode(routerAuthorization);
        }

        public String GetLink(String clientOs)
        {
            if (clientOs == "Android")
            {
                _redirectLink = PlayStore;
            }
            else if (clientOs == "iPhone" || clientOs == "iPad" || clientOs == "iOS")
            {
                _redirectLink = AppStore;
            }
            else
            {
                _redirectLink = Alternative;
            }
            var finalAction = HttpUtility.UrlEncode($"{TrackingAction} | {clientOs}");
            var trackingUrl = $"{CLICKTRACKING}?category={TrackingCategory}&action={finalAction}&authorization={RouterAuthorization}&url={_redirectLink}";

            return trackingUrl;
        }


    }
}