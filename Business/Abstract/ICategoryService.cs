using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId);
        void Add(Category category);
        void Update(Category category);
        void Delete(int categoryId);
        List<CategoryDto> GetCategorytDetails();
    }
}
