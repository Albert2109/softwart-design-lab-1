using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class Product
    {
        public string vumir {  get; set; }
        public string name {  get; set; }
        public Money price { get; set; }
        public Product(string vumir,string name,Money price) {
        this.name = name;
            this.price = price;
            this.vumir = vumir;
        }
        public void DeclarePrice(Money price)
        {

            this.price.ConvertTo(price);
            int sum = price.GetTotalInCents();
            int sum1 = this.price.GetTotalInCents();

            if (sum1 > sum) 
            {
                sum1 -= sum; 
                this.price.SetMoney(sum1); 
            }
            else if (sum1 < sum)
            {
                sum1 = sum; 
                this.price.SetMoney(sum1);
            }
            else
            {
               
                Console.WriteLine("Ціна вже така, як у запиті.");
            }
        }

    }
}
