using Business.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;

        public ProductController(IProductService productService , ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult List()
        {
            var viewModel = _productService.GetProductDetails().Select(x => new ProductListModel
            {
                CategoryName = x.CategoryName,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                UnitInPrice = x.UnitInPrice,
                UnitsInStock = x.UnitsInStock
            }).ToList();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var viewModel = new ProductEditViewModel();
            if (id.HasValue)
            {
                var product = _productService.GetById(id.Value);
                viewModel.ProductId = product.ProductId;
                viewModel.ProductName = product.ProductName;
                viewModel.CategoryId = product.CategoryId;
                viewModel.UnitInPrice = product.UnitInPrice;
                viewModel.UnitsInStock = product.UnitsInStock;
            }
            viewModel.Categories = _categoryService.GetCategorytDetails().Select(x => new CategoryListModel()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(ProductEditViewModel model)
        {
            var product = new Product()
            {
                CategoryId = model.CategoryId,
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                UnitInPrice = model.UnitInPrice,
                UnitsInStock = model.UnitsInStock
            };
            if (model.ProductId==0)
            {
                _productService.Add(product);
            }
            else
            {
                _productService.Update(product);
            }
          
            return RedirectToAction("List");
        }
        
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("List");
        }


    }
}
