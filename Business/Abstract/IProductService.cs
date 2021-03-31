using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int productId);
        List<Product> GetAllByCategoryId(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
        List<ProductDto> GetProductDetails();

    }
}
