using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotterySimulator.Exceptions
{
    /// <summary>
    /// Exception thrown when user try to roll but balance is not enough
    /// </summary>
    internal class OutOfBalanceException: Exception
    {
        public OutOfBalanceException(): base("Not enough money for roll")
        {

        }
    }
}
