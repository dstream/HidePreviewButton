using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace Dstream
{
    [PluginController("HidePreviewButton")]
    [IsBackOffice]
    public class HidePreviewButtonApiController: UmbracoApiController
    {
        [System.Web.Http.HttpGet]
        public bool IsAllow(string url)
        {
            var contentId = ParseContentIdFromUrl(url);
            if (contentId != 0)
            {
                var content = Services.ContentService.GetById(contentId);
                return content != null && AppSettings.Instance.HidePreviewButtonAllowDocTypes.Contains(content.ContentType.Alias);
            }
            return false;
        }

        private int ParseContentIdFromUrl(string url)
        {
            var rg = new Regex(@"^#/content/content/edit/(\d+)$").Match(url);
            if (rg.Success && rg.Groups.Count > 1)
            {
                return int.Parse(rg.Groups[1].Value);
            }
            return 0;
        }
    }
}
