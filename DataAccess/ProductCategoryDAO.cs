using Microsoft.EntityFrameworkCore;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductCategoryDAO
    {
        #region Variable
        private static ProductCategoryDAO instance;
        private static readonly object Lock = new object();
        public static ProductCategoryDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new ProductCategoryDAO();
                    }
                }
                return instance;
            }
        }
        #endregion

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            using var context = new ShoppingDbContext();
            var listCategories = context.ProductCategories.ToList();
            return listCategories;
        }
        public ProductCategory GetCategoryById(int categoryId)
        {
            using var context = new ShoppingDbContext();
            var category = context.ProductCategories.FirstOrDefault(c => c.CategoryId == categoryId);
            return category;
        }
        public bool InsertCategory(ProductCategory category)
        {
            bool status = false;
            try
            {
                using var context = new ShoppingDbContext();
                context.ProductCategories.Add(category);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
        public bool UpdateCategory(ProductCategory category)
        {
            using var context = new ShoppingDbContext();
            bool status = false;
            var checkContainsCategory = GetCategoryById(category.CategoryId);
            if (checkContainsCategory != null)
            {
                try
                {
                    context.Entry<ProductCategory>(category).State = EntityState.Modified;
                    context.SaveChanges();
                    status = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return status;
        }
        public bool DeleteCategory(int categoryId)
        {
            using var context = new ShoppingDbContext();
            bool status = false;
            var checkContainsCategory = GetCategoryById(categoryId);
            if (checkContainsCategory != null)
            {
                try
                {
                    context.ProductCategories.Remove(checkContainsCategory);
                    context.SaveChanges();
                    status = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return status;
        }
    }
}
