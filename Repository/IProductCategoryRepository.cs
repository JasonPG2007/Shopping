using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductCategoryRepository
    {
        public IEnumerable<ProductCategory> GetProductCategories();
        public ProductCategory GetCategoryById(int categoryId);
        public bool InsertCategory(ProductCategory category);
        public bool UpdateCategory(ProductCategory category);
        public bool DeleteCategory(int categoryId);
    }
}
