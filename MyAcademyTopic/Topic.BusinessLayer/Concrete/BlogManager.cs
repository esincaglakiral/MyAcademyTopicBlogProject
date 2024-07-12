﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.BusinessLayer.Abstract;
using Topic.DataAccessLayer.Abstract;
using Topic.EntityLayer.Entities;

namespace Topic.BusinessLayer.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IBlogDal _blogDal;
        public BlogManager(IGenericDal<Blog> genericDal, IBlogDal blogDal) : base(genericDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> TGetBlogBySearchKeyword(string keyword)
        {
            return _blogDal.GetBlogBySearchKeyword(keyword);
        }

        public int TGetBlogCount()
        {
            return _blogDal.GetBlogCount();
        }

        public List<Blog> TGetBlogsByCategoryId(int id)
        {
            return _blogDal.GetBlogsByCategoryId(id);
        }

   

        public List<Blog> TGetBlogsWithCategories() 
        {
            return _blogDal.GetBlogsWithCategories();
        }

        public Blog TGetBlogWithCategoryById(int id)
        {
            return _blogDal.GetBlogWithCategoryById(id);
        }
    }
}