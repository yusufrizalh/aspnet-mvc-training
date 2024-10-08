﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Show(int? id)
        {
            var category = CategoriesRepository.GetCategoryById(
                id.HasValue ? id.Value : 0);
            return View(category);
        }

        [HttpPost]
        public IActionResult Show(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(
                category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

    }
}
