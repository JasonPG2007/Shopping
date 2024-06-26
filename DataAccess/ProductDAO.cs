﻿using Microsoft.EntityFrameworkCore;
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
        #region Variable
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
        #endregion

        public IEnumerable<Product> GetProducts()
        {
            using var context = new ShoppingDbContext();
            var listProducts = context.Products.ToList();
            return listProducts;
        }
        public Product GetProductById(int productId)
        {
            using var context = new ShoppingDbContext();
            var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
            return product;
        }
        public bool InsertProduct(Product product)
        {
            bool status = false;
            try
            {
                using var context = new ShoppingDbContext();
                context.Products.Add(product);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
        public bool UpdateProduct(Product product)
        {
            using var context = new ShoppingDbContext();
            bool status = false;
            var checkContainsProduct = GetProductById(product.ProductId);
            if (checkContainsProduct != null)
            {
                try
                {
                    context.Entry<Product>(product).State = EntityState.Modified;
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
        public bool DeleteProduct(int productId)
        {
            using var context = new ShoppingDbContext();
            bool status = false;
            var checkContainsProduct = GetProductById(productId);
            if (checkContainsProduct != null)
            {
                try
                {
                    context.Products.Remove(checkContainsProduct);
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
