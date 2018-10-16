using Suporteri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suporteri.DataAccessLayer
{
    public class ProductDAL
    {
        public List<Product> GetProductList()
        {
            List<Product> list = new List<Product>();
            using (var context = new ProductContext())
            {
                // Perform data access using the context 
                list = context.Product.ToList();
            }
            return list;
        }

        public void AddProduct(Product product)
        {
            if (product != null)
            {
                using (var context = new ProductContext())
                {
                    // Perform data access using the context 
                    context.Product.Add(product);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(Product product)
        {
            if (product != null)
            {
                using (var context = new ProductContext())
                {
                    // Perform data access using the context 
                    context.Product.Remove(product);
                    context.SaveChanges();
                }
            }
        }

        public void Edit(Product product)
        {
            if (product != null)
            {
                using (var context = new ProductContext())
                {
                    Product prod = context.Product.FirstOrDefault(p=>p.ProductID == product.ProductID);
                    prod.ProductName = product.ProductName;
                    prod.UnitPrice = product.UnitPrice;
                    prod.ImagePath = product.ImagePath;
                    context.Product.Add(prod);
                    context.SaveChanges();
                }
            }
        }
    }
}