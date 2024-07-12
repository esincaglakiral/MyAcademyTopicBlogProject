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
    public class EfBlogDal : GenericRepository<Blog>, IBlogDal
    {
        public EfBlogDal(TopicContext context) : base(context)  //GenericRepository da contexti constructor olarak geçtiğimiz için burdada geçeriz
        {
        }

        public List<Blog> GetBlogBySearchKeyword(string keyword)
        {
            return _context.Blogs.Include(t => t.Category).Where(x => x.Category.CategoryName.Contains(keyword) || x.Title.Contains(keyword)).ToList();
        }

        public int GetBlogCount()
        {
            return _context.Blogs.Count();
        }

        public List<Blog> GetBlogsByCategoryId(int id)
        {
            return _context.Blogs.Where(x => x.CategoryId == id).ToList();
        }


        public List<Blog> GetBlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.Category).ToList();  //bloglar listelenirken kategori id'si değil adının gözükmesi için bu metodu oluşturduk.
        }

        public Blog GetBlogWithCategoryById(int id) //Id ye göre tek değer dönüyor. Blogları getirirken kategorilerini de dahil eder.
        {
            return _context.Blogs.Include(x => x.Category).FirstOrDefault(x => x.BlogId == id);
        }
    }
}
