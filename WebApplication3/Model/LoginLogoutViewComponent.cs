using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Model
{
    public class LoginLogoutViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}