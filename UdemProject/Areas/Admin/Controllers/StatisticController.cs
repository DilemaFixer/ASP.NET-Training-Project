using Microsoft.AspNetCore.Mvc;
using UdemProject.Data;
using UdemProject.Data.IRepository.Category;

namespace UdemProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class StatisticController : Controller
    {
        private ICategoryInterafce _category;

        public StatisticController(ICategoryInterafce category)
        {
            _category = category;
        }

        public ActionResult Index()
        {
            List<Category> categories = _category.GetAll().ToList();
            return View(categories);
        }
    }
}
