using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _appDbContext.Categories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _appDbContext.Categories.Add(category);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var categoryFromDb = _appDbContext.Categories.Find(id);
            //var categoryFromDbFirst = _appDbContext.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _appDbContext.Categories.SingleOrDefault(c => c.Id == id);

            if (categoryFromDb == null) return NotFound();

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _appDbContext.Categories.Update(category);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
