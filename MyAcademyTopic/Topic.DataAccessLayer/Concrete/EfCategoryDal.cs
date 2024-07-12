using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.DataAccessLayer.Abstract;
using Topic.DataAccessLayer.Context;
using Topic.DataAccessLayer.Repositories;
using Topic.EntityLayer.Entities;

namespace Topic.DataAccessLayer.Concrete
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(TopicContext context) : base(context)
        {
        }

        public List<Category> GetActiveCategoriesWithBlogs()
        {
            return _context.Categories.Include(f => f.Blogs).Where(t => t.Status == true).ToList();
        }

        public int GetActiveCategoryCount()
        {
            return _context.Categories.Where(t => t.Status == true).Count();
        }

        public int GetAllCategoryCount()
        {
            return _context.Categories.Count();
        }
    }
}
