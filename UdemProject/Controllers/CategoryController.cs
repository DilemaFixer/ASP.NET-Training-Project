using Microsoft.AspNetCore.Mvc;
using UdemProject.Data;

namespace UdemProject.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext ApplicationDbContext;
        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
           List<Category> categories = ApplicationDbContext.Category.ToList();
            return View(categories);
        }
    }
}
