using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bankomat.DB {

    interface IBankDB
    {
        CreditCard getCreditCard(string cardNo, string pin);

        decimal getBalance(CreditCard card);

        bool payMoney(CreditCard card, decimal amount);

        bool changePin(CreditCard card, string currentPin, string newPin);

        bool IsCorrectPin(string cardNo, string pin);

        bool verifyCardNumber(string cardNo);
       
    }
}
