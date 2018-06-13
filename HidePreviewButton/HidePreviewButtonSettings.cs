using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Dstream
{
    public class AppSettings
    {
        #region singleton        
        private static readonly Lazy<AppSettings> lazy = new Lazy<AppSettings>(() => new AppSettings());

        public static AppSettings Instance { get { return lazy.Value; } }

        private AppSettings()
        {
        }
        #endregion

        public List<string> HidePreviewButtonAllowDocTypes { get {
                var appsetting = GetApplicationSetting("hidePreviewButtonAllowDocTypes", "");
                if (string.IsNullOrEmpty(appsetting)) return new List<string>();
                return appsetting.ToLower().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        private string GetApplicationSetting(string key, string defaultValue)
        {
            var val = ConfigurationManager.AppSettings[key];
            return string.IsNullOrEmpty(val) ? defaultValue : val;
        }
    }
}
