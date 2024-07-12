using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.BusinessLayer.Abstract;
using Topic.DataAccessLayer.Abstract;
using Topic.DataAccessLayer.Concrete;
using Topic.EntityLayer.Entities;

namespace Topic.BusinessLayer.Concrete
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(IGenericDal<Category> genericDal, ICategoryDal categoryDal) : base(genericDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> TGetActiveCategoriesWithBlogs()
        {
            return _categoryDal.GetActiveCategoriesWithBlogs();
        }

        public int TGetActiveCategoryCount()
        {
            return _categoryDal.GetActiveCategoryCount();
        }

        public int TGetAllCategoryCount()
        {
            return _categoryDal.GetAllCategoryCount();
        }
    }
}
