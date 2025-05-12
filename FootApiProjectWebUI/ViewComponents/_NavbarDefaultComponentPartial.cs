using Microsoft.AspNetCore.Mvc;

namespace FootApiWebUI.ViewComponents
{
    public class _NavbarDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
        
    }
}
