﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //Bağımlılığı minimize et
        ICategoryDal _categoryDal;


        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            // İş Kodları
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            // select * from categories where categoryId==3
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
