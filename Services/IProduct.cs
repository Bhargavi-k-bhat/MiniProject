using LimeLemon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimeLemon.Services
{
    interface IProduct
    {
        public bool addProduct(Product product);
        public List<Product> GetProducts();
        public Product getProductByName(string itemType);
        public bool updateProductByName(Product product);
        //public List<Product> getproductsType(string itemType);
        public bool deleteByName(string itemName);


    }
}
