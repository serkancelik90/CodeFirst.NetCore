using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            var deletedCar = _productDal.Get(x => x.ProductId == productId);
            _productDal.Delete(deletedCar);
        }

        public List<Product> GetAll()
        {
           return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(x=>x.CategoryId==id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(x => x.ProductId == productId);
        }

        public List<ProductDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
