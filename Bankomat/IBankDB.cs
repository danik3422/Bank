﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bankomat.DB {

    interface IBankDB
    {
        CreditCard getCreditCard(string cardNo, int pin);

        decimal getBalance(CreditCard card);

        bool payMoney(CreditCard card, decimal amount);

        bool changePin(CreditCard card, int currentPin, int newPin);

        bool verifyCardNumber(string cardNo);
    }
}
