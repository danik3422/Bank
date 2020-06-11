using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bankomat.DB {

    interface BankDB
    {
        CreditCard getCreditCard(string cardNo, int pin);

        decimal getBalance(CreditCard card);

        void changeBalance(CreditCard card, decimal newBalance);

        void changePin(CreditCard card, int currentPin, int newPin);

        bool verifyCardNumber(string cardNo);
    }
}
