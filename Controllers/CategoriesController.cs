using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetAllCategories();
            return View(categories);
        }

        public IActionResult Show(int? id)
        {
            var category = new Category
            {
                CategoryId = id.HasValue ? id.Value : 0
            };
            return View(category);
        }
    }
}
