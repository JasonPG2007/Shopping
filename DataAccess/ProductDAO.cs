using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance;
        private static readonly object Lock = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                }
                return instance;
            }
        }
        public IEnumerable<Product> GetProducts()
        {
            using var context = new ShoppingDbContext();
            var listProducts = context.Products.ToList();
            return listProducts;
        }
    }
}
