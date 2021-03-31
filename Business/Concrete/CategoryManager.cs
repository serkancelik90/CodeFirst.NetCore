using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(int categoryId)
        {
          var deletedEntity =  _categoryDal.Get(x => x.CategoryId == categoryId);
            _categoryDal.Delete(deletedEntity);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(x => x.CategoryId == categoryId);
        }

        public List<CategoryDto> GetCategorytDetails()
        {
            return _categoryDal.GetCategoryDetails();
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
