using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.DB
{
    struct BankAccount
    {
        int AccountId { get; }
        int CustomerId { get; }
        string AccountNo { get; }
        decimal Balance { get; }
    }
}
