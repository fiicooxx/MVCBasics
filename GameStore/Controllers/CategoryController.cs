using GameStore.Data;
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
            var objCategoryList = _appDbContext.Categories.ToList();
            return View();
        }
    }
}
