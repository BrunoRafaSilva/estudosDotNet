using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using identifyOs.Interfaces;

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
        private string _redirectLink { get; set; }

        const string CLICKTRACKING = "https://click-tracking.cs.blip.ai/api/Track";
        public DynamicLinkParams(string trackingCategory, string trackingAction, string playStore, string appStore, string alternative, string routerAuthorization)
        {
            TrackingCategory = HttpUtility.UrlEncode(trackingCategory);
            TrackingAction = HttpUtility.UrlEncode(trackingAction);
            PlayStore = HttpUtility.UrlEncode(playStore);
            AppStore = HttpUtility.UrlEncode(appStore);
            Alternative = HttpUtility.UrlEncode(alternative);
            RouterAuthorization = HttpUtility.UrlEncode(routerAuthorization);
        }

        public string GetLink(string clientOs)
        {
            if (clientOs == "ANDROID")
            {
                _redirectLink = PlayStore;
            }
            else if (clientOs == "IOS")
            {
                _redirectLink = AppStore;
            }
            else
            {
                _redirectLink = Alternative;
            }
            var trackingUrl = $"{CLICKTRACKING}?category={TrackingCategory}&action={TrackingAction}&authorization={RouterAuthorization}&url={_redirectLink}";

            return trackingUrl;
        }


    }
}