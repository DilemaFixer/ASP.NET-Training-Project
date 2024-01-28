using Microsoft.AspNetCore.Mvc;
using UdemProject.Data;
using UdemProject.Data.IRepository.Category;

namespace UdemProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryInterafce _categoryDataBase;
        public CategoryController(ICategoryInterafce applicationDbContext)
        {
            _categoryDataBase = applicationDbContext;
        }

        public IActionResult Index()
        {
            List<Category> categories = _categoryDataBase.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryDataBase.Add(category);
                _categoryDataBase.Save();
                return RedirectToAction("Index");
            }

            if (category.Name == null)
            {
                ModelState.AddModelError("Name", "Name is null");
                return View();
            }

            if (category.Name.ToLower() == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name the same as display order");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category targetCategory = _categoryDataBase.Get(c => c.Id == id);

            if (targetCategory == null)
                return NotFound(nameof(targetCategory));

            return View(targetCategory);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryDataBase.Update(category);
                _categoryDataBase.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category targetCategory = _categoryDataBase.Get(c => c.Id == id);

            if (targetCategory == null)
                return NotFound(nameof(targetCategory));

            return View(targetCategory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _categoryDataBase.Get(u => u.Id == id);

            if (category == null)
                return NotFound();

            _categoryDataBase.Remove(category);
            _categoryDataBase.Save();
            return RedirectToAction("Index");
        }
    }
}
