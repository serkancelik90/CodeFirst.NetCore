using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult List()
        {
            var viewModel = _categoryService.GetCategorytDetails().Select(x => new CategoryListModel()
            {
                 CategoryId=x.CategoryId,
                  CategoryName=x.CategoryName
            }).ToList();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var viewModel = new CategoryEditViewModel();
            if (id.HasValue)
            {
                var category = _categoryService.GetById(id.Value);
                viewModel.CategoryId = category.CategoryId;
                viewModel.CategoryName = category.CategoryName;
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(CategoryEditViewModel model)
        {
            var category = new Category()
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName
            };
            if (model.CategoryId==0)
            {
                _categoryService.Add(category);
            }
            else
            {
                _categoryService.Update(category);
            }
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
