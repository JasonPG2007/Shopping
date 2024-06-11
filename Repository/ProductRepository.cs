using DataAccess;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        public bool DeleteProduct(int productId) => ProductDAO.Instance.DeleteProduct(productId);

        public Product GetProductById(int productId) => ProductDAO.Instance.GetProductById(productId);

        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProducts();

        public bool InsertProduct(Product product) => ProductDAO.Instance.InsertProduct(product);

        public bool UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
    }
}
