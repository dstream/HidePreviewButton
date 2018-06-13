using Umbraco.Core;
using Umbraco.Web.Editors;
using Umbraco.Web.Models.ContentEditing;

namespace Dstream
{
    public class HidePreviewButtonBootstraper: ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationStarted(umbracoApplication, applicationContext);

            EditorModelEventManager.SendingContentModel += (sender, e) =>
            {
                var contentModel = e.Model as ContentItemDisplay;
                if (contentModel != null && AppSettings.Instance.HidePreviewButtonAllowDocTypes.Contains(contentModel.ContentTypeAlias))
                {
                    contentModel.AllowPreview = true;
                }
                else
                {
                    contentModel.AllowPreview = false;
                }
            };

        }
    }
}
