using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public interface ITransactionLogger
    {
        void RecordIn(Product product, int quantity);
        void RecordOut(Product product, int quantity);
        List<string> GetLog();
    }

}
