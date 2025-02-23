using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class TransactionLogger : ITransactionLogger
    {
        private List<string> _log;

        public TransactionLogger()
        {
            _log = new List<string>();
        }

        public void RecordIn(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentException("Помилка: кількість повинна бути більшою за 0!");

            _log.Add($"{DateTime.Now}: отримано {product.name} кількість {quantity} {product.vumir}");
        }

        public void RecordOut(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentException("Помилка: кількість повинна бути більшою за 0!");

            _log.Add($"{DateTime.Now}: видалено {product.name} кількість {quantity} {product.vumir}");
        }

        public List<string> GetLog()
        {
            return _log;
        }
    }

}
