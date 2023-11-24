using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface IProductService
    {
        public Product AddProduct(Product product);
        public Product UpdateProductPrice(int id, float price);
        public Product GetProduct(int id);
        public List<Product> GetProducts();
        public Product UpdateProductQuantity(int id, int quantity, string action);
        public Product Delete(int id);
    }
}

