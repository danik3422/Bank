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
        private readonly Action<string> errorAction;

        public BankDB(Action<string> errorAction)
        {
            this.errorAction = errorAction;
        }

        public bool payMoney(CreditCard card, decimal amount)
        {
            decimal balance = getBalance(card);
            if (balance < 0)
            {
                return false;
            }
            if (amount > balance)
            {
                errorAction("Not enough money!");
                return false;
            }
            try
            {
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
            catch (Exception e)
            {
                errorAction(e.Message);
                return false;
            }
        }


        public bool changePin(CreditCard card, string currentPin, string newPin)
        {
            if (!IsCorrectPin(card.CardNo, currentPin))
            {
                errorAction("Incorrect Pin!");
                return false;
            }
            if (!DBUtils.IsPinValid(newPin))
            {
                errorAction("New Pin is invalid");
                return false;
            }
            try
            {
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
            catch (Exception e)
            {
                errorAction(e.Message);
                return false;
            }
        }

        public decimal getBalance(CreditCard card)
        {
            decimal balance = -1;
            try
            {
                using (var connection = DBUtils.GetConnection())
                {
                    using (var command = DBUtils.BalanceQuery(card))
                    {
                        command.Connection = connection;
                        connection.Open();
                        var result = command.ExecuteReader();
                        if (result.HasRows)
                        {
                            result.Read();
                            balance = DBUtils.GetBalance(result);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                balance = -1;
                errorAction(e.Message);
            }
            return balance;
        }

        public CreditCard getCreditCard(string cardNo, string pin)
        {
            CreditCard card = null;
            if (!DBUtils.IsCardNumberValid(cardNo))
            {
                errorAction("Invalid card number!");
                return card;
            }
            if (!IsCorrectPin(cardNo, pin))
            {
                errorAction("Incorrect Pin!");
                return card;
            }
            try
            {
                using (var connection = DBUtils.GetConnection())
                {
                    using (var command = DBUtils.CreditCardDataQuery(cardNo))
                    {
                        command.Connection = connection;
                        connection.Open();
                        var result = command.ExecuteReader();
                        if (result.Read())
                        {
                            card = DBUtils.CreateCard(result);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                card = null;
                errorAction(e.Message);
            }
            return card;
        }

        private bool IsCorrectPin(string cardNo, string pin)
        {
            if (!DBUtils.IsPinValid(pin))
            {
                return false;
            }

            bool correctPin = false;
            try
            {
                using (var connection = DBUtils.GetConnection())
                {
                    using (var command = DBUtils.CreditCardPinQuery(cardNo))
                    {
                        command.Connection = connection;
                        connection.Open();
                        var result = command.ExecuteReader();
                        if (result.HasRows)
                        {
                            result.Read();
                            string storedPin = DBUtils.GetPin(result);
                            correctPin = pin.Equals(storedPin);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                correctPin = false;
                errorAction(e.Message);
            }
            return correctPin;
        }

        public bool verifyCardNumber(string cardNo)
        {
            if (!DBUtils.IsCardNumberValid(cardNo))
            {
                errorAction("Invalid card number!");
                return false;
            }
            bool isValidNumber = false;
            try
            {
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
            }
            catch (Exception e)
            {
                isValidNumber = false;
                errorAction(e.Message);
            }
            return isValidNumber;
        }

    }
}
