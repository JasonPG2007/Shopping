using DataAccess;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        public bool DeleteCategory(int categoryId) => ProductCategoryDAO.Instance.DeleteCategory(categoryId);

        public ProductCategory GetCategoryById(int categoryId) => ProductCategoryDAO.Instance.GetCategoryById(categoryId);

        public IEnumerable<ProductCategory> GetProductCategories() => ProductCategoryDAO.Instance.GetProductCategories();

        public bool InsertCategory(ProductCategory category) => ProductCategoryDAO.Instance.InsertCategory(category);

        public bool UpdateCategory(ProductCategory category) => ProductCategoryDAO.Instance.UpdateCategory(category);
    }
}
