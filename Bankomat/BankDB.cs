using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bankomat.DB
{
    class BankDB : IBankDB
    {

        public bool payMoney(CreditCard card, decimal amount)
        {
            decimal balance = getBalance(card);
            if (balance < 0 || amount < 0)
            {
                return false;
            }
            if (amount > balance)
            {
                OnError("Za mało pieniędzy na kontie!");
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
                OnError(e.Message);
                return false;
            }
        }


        public bool changePin(CreditCard card, string currentPin, string newPin)
        {
            if (!IsCorrectPin(card.CardNo, currentPin))
            {
                OnError("Nieprawidłowe hasło!");
                return false;
            }
            if (!DBUtils.IsPinValid(newPin))
            {
                OnError("Nowe hasło nie jest poprawne!");
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
                OnError(e.Message);
                return false;
            }
        }

        private void OnError(string message)
        {
            MessageBox.Show(message, "ATM System", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        else 
                        {
                            OnError("Wrong card");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                balance = -1;
                OnError(e.Message);
            }
            return balance;
        }

        public CreditCard getCreditCard(string cardNo, string pin)
        {
            CreditCard card = null;
            if (!DBUtils.IsCardNumberValid(cardNo))
            {
                OnError("Nieprawidłowy numer karty!");
                return card;
            }
            if (!IsCorrectPin(cardNo, pin))
            {
                OnError("Nieprawidłowy Pin!");
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
                        else
                        {
                            OnError("Wrong card!");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                card = null;
                OnError(e.Message);
            }
            return card;
        }

        public bool IsCorrectPin(string cardNo, string pin)
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
                        else
                        {
                            OnError("Wrong card!");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                correctPin = false;
                OnError(e.Message);
            }
            return correctPin;
        }

        public bool verifyCardNumber(string cardNo)
        {
            if (!DBUtils.IsCardNumberValid(cardNo))
            {
                OnError("Nieprawidłowy numer karty!");
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
                        if (!isValidNumber)
                        {
                            OnError("Wrong card!");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                isValidNumber = false;
                OnError(e.Message);
            }
            return isValidNumber;
        }
    }
}
