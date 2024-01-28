using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemProject.Data;
using UdemProject.Data.IRepository.Product;

namespace UdemProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IProductRepository _db;
        public ProductController(IProductRepository db) => _db = db;

        public ActionResult Index()
        {
            List<Data.Product> products = _db.GetAll().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            var products =_db.GetAll().ToList();
            ProductVM productVM = new ProductVM
            {
                Product = new Product(),
                Category = products.Select(c => new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                })
            };
            
            return View(productVM);
        }
        
        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                _db.Add(productVM.Product);
                _db.Save();
                return RedirectToAction("Index");
            }
            else
            {
                 productVM.Category = _db.GetAll().Select(c => new SelectListItem 
                 {
                     Text = c.Title,
                     Value = c.Id.ToString()
                 });
                 return View(productVM);
            }
        }

        public ActionResult Edit(int? id)
        {
            ProductVM productVM = new ProductVM
            {
                Product =  _db.Get(pr => pr.Id == id),
                Category = _db.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Title,
                    Value = c.Id.ToString()
                })
            };
            
            if(productVM == null) 
                return RedirectToAction("Index");

            return View(productVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM product)
        {
            if (ModelState.IsValid)
            {
                _db.Update(product.Product);
                _db.Save();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Product targetCategory = _db.Get(c => c.Id == id);

            if (targetCategory == null)
                return NotFound(nameof(targetCategory));

            return View(targetCategory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? category = _db.Get(u => u.Id == id);

            if (category == null)
                return NotFound();

            _db.Remove(category);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}
