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
            var categoryList = _categoryService.GetCategory();
            return View(await categoryList);
        }

        [HttpGet]
        [Route("Get")]
        [Produces(typeof(IEnumerable<Category>))]
        public async Task<IActionResult> GetCategory()
        {
            var category = await _categoryService.GetCategory();
            return View(category);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [Produces(typeof(Category))]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return View(category);
        }

        [HttpGet]
        [Route("Add")]
        [Produces(typeof(Category))]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [Route("Add/{id}")]
        [Produces(typeof(Category))]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var _category = _categoryService.AddCategory(category);
                return View(_category);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Update")]
        [Produces(typeof(Category))]
        public IActionResult UpdateCategory()
        {
            return View();
        }

        [HttpPut]
        [Route("Update")]
        [Produces(typeof(Category))]
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
        [Route("Delete")]
        [Produces(typeof(Category))]
        public IActionResult DeleteCategory()
        {
            return View();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [Produces(typeof(bool))]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            bool isDeleted = await _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
