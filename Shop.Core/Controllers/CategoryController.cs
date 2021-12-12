using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Core.Controllers
{
    [Route("category/")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categoryList = await _categoryService.GetCategory();
            return View(categoryList);
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var _category = _categoryService.AddCategory(category);
                //return View(_category);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Update")]
        public IActionResult UpdateCategory()
        {
            return View();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var _category = await _categoryService.UpdateCategory(category);
                return View(_category);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(Category category)
        {
            bool isDeleted = await _categoryService.DeleteCategory(category.Id);
            if(isDeleted == true)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
