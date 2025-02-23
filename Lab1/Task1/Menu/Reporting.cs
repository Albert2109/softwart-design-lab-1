using System;
using System.Collections.Generic;

namespace Menu
{
    public class Reporting
    {
        private Warehouse _warehouse;

        public Reporting(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void ShowReport(List<string> records)
        {
            if (records == null || records.Count == 0)
            {
                Console.WriteLine("Не записано жодної транзакції.");
                return;
            }

            Console.WriteLine("\nЗвіт по транзакціях");
            foreach (var record in records)
            {
                Console.WriteLine(record);
            }
        }

        public void GenerateInventoryReport(List<Product> products)
        {
            Console.WriteLine("\nЗвіт по залишкам:");
            foreach (var product in products)
            {
                Console.WriteLine($"Продукт: {product.name}, Одиниця виміру: {product.vumir}, Ціна: {product.price.Sum()}");
            }
        }
    }
}
