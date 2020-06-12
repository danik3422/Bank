using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.DB
{
    class BankDB : IBankDB
    {
        public bool payMoney(CreditCard card, decimal amount)
        {
            decimal balance = getBalance(card);
            if (balance < 0)
            {
                return false;
            }
            if (amount > balance)
            {
                return false;
            }
            using (var connection = DBUtils.GetConnection())
            {
                using (var command = DBUtils.BalanceUpdate(card, balance - amount))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }


        public bool changePin(CreditCard card, int currentPin, int newPin)
        {
            if (!IsCorrectPin(card.CardNo, currentPin))
            {
                return false;
            }
            using (var connection = DBUtils.GetConnection())
            {
                using (var command = DBUtils.CardPinUpdate(card, newPin))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return true;

        }

        public decimal getBalance(CreditCard card)
        {
            decimal balance = -1;
            using (var connection = DBUtils.GetConnection())
            {
                using (var command = DBUtils.BalanceQuery(card))
                {
                    command.Connection = connection;
                    connection.Open();
                    var result = command.ExecuteReader();
                    if (result.HasRows)
                    {
                        balance = DBUtils.GetBalance(result);
                    }
                }
            }
            return balance;
        }

        public CreditCard getCreditCard(string cardNo, int pin)
        {
            CreditCard card = null;
            if (!DBUtils.IsCardNumberValid(cardNo) || !IsCorrectPin(cardNo, pin))
            {
                return card;
            }
            using (var connection = DBUtils.GetConnection())
            {
                using (var command = DBUtils.CreditCardDataQuery(cardNo))
                {
                    command.Connection = connection;
                    connection.Open();
                    var result = command.ExecuteReader();
                    if (result.HasRows)
                    {
                        card = DBUtils.CreateCard(result);
                    }
                }
            }
            return card;
        }




        private bool IsCorrectPin(string cardNo, int pin)
        {
            bool correctPin = false;
            using (var connection = DBUtils.GetConnection())
            {
                using (var command = DBUtils.CreditCardPinQuery(cardNo))
                {
                    command.Connection = connection;
                    connection.Open();
                    var result = command.ExecuteReader();
                    if (result.HasRows)
                    {
                        object storedPin = DBUtils.GetPin(result);
                        correctPin = pin.Equals(storedPin);
                    }
                }
            }
            return correctPin;
        }


        public bool verifyCardNumber(string cardNo)
        {
            if (!DBUtils.IsCardNumberValid(cardNo))
            {
                return false;
            }
            bool isValidNumber = false;
            using (var connection = DBUtils.GetConnection())
            {
                using (var command = DBUtils.CreditCardNumberQuery(cardNo))
                {
                    command.Connection = connection;
                    connection.Open();
                    var result = command.ExecuteReader();
                    isValidNumber = result.HasRows;
                }
            }
            return isValidNumber;
        }

    }
}
