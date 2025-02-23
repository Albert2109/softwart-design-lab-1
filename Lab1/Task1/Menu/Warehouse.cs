using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class Warehouse
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public int Quantity => Products.Count;
        private DateTime Data { get; set; }

        public Warehouse(Product product)
        {
            Products.Add(product);
            this.Data = DateTime.Now;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }
    }

}
