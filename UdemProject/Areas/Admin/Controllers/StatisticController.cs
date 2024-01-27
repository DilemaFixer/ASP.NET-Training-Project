using Microsoft.AspNetCore.Mvc;

namespace UdemProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class StatisticController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
