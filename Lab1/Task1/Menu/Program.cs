using System;
using System.Collections.Generic;
using System.Text;

namespace Menu
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            
            Money moneyUSD = new Money(100, 50, "USD", 1.0m);
            Money moneyEUR = new Money(80, 20, "EUR", 1.1m);
            Product apple = new Product("кг", "Яблуко", moneyUSD);
            Product banana = new Product("кг", "Банан", moneyEUR);

            apple.DeclarePrice(moneyEUR);
            Console.WriteLine("\nПісля зміни ціни:");
            Console.WriteLine($"Яблуко: {apple.price.Sum()}");
            Warehouse warehouse = new Warehouse(apple);
            ITransactionLogger transactionLogger = new TransactionLogger();

           
            WarehouseManager warehouseManager = new WarehouseManager(warehouse, transactionLogger);

            
            warehouseManager.AddProductWithLogging(banana);
            warehouseManager.RemoveProductWithLogging(apple);

            

          
            Reporting reporting = new Reporting(warehouse);
            reporting.ShowReport(transactionLogger.GetLog());
            reporting.GenerateInventoryReport(warehouse.Products);

           
            var convertedMoney = moneyUSD.ConvertTo(moneyEUR);
            Console.WriteLine($"\nКонвертовані гроші: {convertedMoney.Sum()}");
        }
    }
}
