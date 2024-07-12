﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.EntityLayer.Entities;

namespace Topic.BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        List<Category> TGetActiveCategoriesWithBlogs();

        public int TGetActiveCategoryCount();
        public int TGetAllCategoryCount();
    }
}