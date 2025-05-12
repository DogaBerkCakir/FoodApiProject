using Microsoft.AspNetCore.Mvc;

namespace FootApiWebUI.ViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
