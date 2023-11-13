using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulator.Exceptions
{
    internal class OutOfBalanceException: Exception
    {
        public OutOfBalanceException(): base("Not enough money for roll")
        {

        }
    }
}
