using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.DB
{
    public class CreditCard
    {
        public CreditCard(string cardNo, int accountId, int customerId, string cardHolder)
        {
            CardNo = cardNo;
            AccountId = accountId;
            CustomerId = customerId;
            CardHolder = cardHolder;
        }

        public string CardNo { get; private set; }
        public int AccountId { get; private set; }
        public int CustomerId { get; private set; }
        public string CardHolder { get; private set; }
    }
}
