using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.DB
{
    struct CreditCard
    {
        string CardNo { get; }
        int AccountId { get; }
        int CustomerId { get; }
        string CardHolder { get; }
    }
}
