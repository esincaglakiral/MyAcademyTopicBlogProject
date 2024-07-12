using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Topic.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



    }
}
