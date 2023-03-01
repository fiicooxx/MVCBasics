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
    }
}
