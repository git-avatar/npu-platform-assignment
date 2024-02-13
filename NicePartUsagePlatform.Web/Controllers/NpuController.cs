using Microsoft.AspNetCore.Mvc;

namespace NicePartUsagePlatform.Web.Controllers
{
    public class NpuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
