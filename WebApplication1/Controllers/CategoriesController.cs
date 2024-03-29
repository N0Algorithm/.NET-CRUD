﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }
   		public IActionResult Edit(int? id)
		{
            var category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value:0);

			return View(category);
		}

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
				CategoriesRepository.UpdateCategory(category.CategoryId, category);
				return RedirectToAction(nameof(Index));

			}
            return View(category);
        }
	}
}
