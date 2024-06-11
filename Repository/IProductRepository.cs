using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProductById(int productId);
        public bool InsertProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(int productId);
    }
}
