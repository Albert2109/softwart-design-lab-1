using System;

namespace Menu
{
    public class WarehouseManager
    {
        private Warehouse _warehouse;
        private ITransactionLogger _transactionLogger;

        public WarehouseManager(Warehouse warehouse, ITransactionLogger transactionLogger)
        {
            _warehouse = warehouse;
            _transactionLogger = transactionLogger;
        }

        public void AddProductWithLogging(Product product)
        {
            _warehouse.AddProduct(product);
            _transactionLogger.RecordIn(product, 1); 
        }

        public void RemoveProductWithLogging(Product product)
        {
            _warehouse.RemoveProduct(product);
            _transactionLogger.RecordOut(product, 1); 
        }
    }
}
