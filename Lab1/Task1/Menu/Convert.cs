using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
   public  interface Convert
    {
        Money ConvertTo(Money target);
    }
}
