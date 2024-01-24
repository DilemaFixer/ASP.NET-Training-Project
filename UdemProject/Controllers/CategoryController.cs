using Microsoft.AspNetCore.Mvc;
using UdemProject.Data;

namespace UdemProject.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _applicationDbContext;
        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
           List<Category> categories = _applicationDbContext.Category.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _applicationDbContext.Category.Add(category);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
