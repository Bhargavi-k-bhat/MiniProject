using LimeLemon.Models;
using LimeLemon.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimeLemon.DataAccessLayer
{
    public class ProductServices : IProduct
    {
        public MiniProject1Context context = null;
        public ProductServices()
        {
            context = new MiniProject1Context();
        }
        public bool addProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return true;
        }

        public bool deleteByName(string itemName)
        {
            Product product = context.Products.Find(itemName);
            context.Products.Remove(product);
            context.SaveChanges();
            return true;
        }

        public Product getProductByName(string itemName)
        {
            List<Product> products = context.Products.IgnoreAutoIncludes().ToList();
            Product products1 = null;
            foreach (var item in products)
            {
                if (itemName == item.ItemName)
                {
                    products1 = item;
                    break;
                }
            }
            return products1;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = context.Products.ToList();
            return products;
        }

        public bool updateProductByName(Product product)
        {
            Product product1 = (from p in context.Products where p.ItemName == product.ItemName select p).SingleOrDefault();
            if (product1 != null)
            {

                product1.ItemPrice = product.ItemPrice;

            }
            context.SaveChanges();
            return true;
        }
    }
}
