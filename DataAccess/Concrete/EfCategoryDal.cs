using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ProductContext>, ICategoryDal
    {
        public List<CategoryDto> GetCategoryDetails()
        {
            using (ProductContext context = new ProductContext())
            {
                var result = from c in context.Categories
                             select new CategoryDto
                             {
                                 CategoryId = c.CategoryId,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();
            }
        }
    }
}
