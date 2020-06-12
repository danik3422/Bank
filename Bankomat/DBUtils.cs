using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.DB
{
    public static class DBUtils
    {
        private const string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\App_Data\\Database1.mdf;Integrated Security=True";
        private const int CARD_NUMER_LENGTH = 6;


        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static SqlCommand CreditCardDataQuery(string cardNo)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT CardNo, AccountId, CustomerId, CardHolder FROM CreditCards WHERE CardNo = @crd;";
            command.Parameters.AddWithValue("@crd", cardNo);
            return command;
        }
        public static SqlCommand CreditCardNumberQuery(string cardNo)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT CardNo FROM CreditCards WHERE CardNo = @crd;";
            command.Parameters.AddWithValue("@crd", cardNo);
            return command;
        }
        public static SqlCommand CreditCardPinQuery(string cardNo)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT PIN FROM CreditCards WHERE CardNo = @crd;";
            command.Parameters.AddWithValue("@crd", cardNo);
            return command;
        }

        public static SqlCommand BalanceQuery(CreditCard card)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Balance FROM BankAccounts WHERE AccountId = @acc;";
            command.Parameters.AddWithValue("@acc", card.AccountId);
            return command;
        }

        public static SqlCommand BalanceUpdate(CreditCard card, decimal newBalance)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE BankAccounts SET Balance = @bal WHERE AccountId = @acc;";
            command.Parameters.AddWithValue("@bal", newBalance);
            command.Parameters.AddWithValue("@acc", card.AccountId);
            return command;
        }

        public static SqlCommand CardPinUpdate(CreditCard card, int newPin)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE CreditCards SET PIN = @pin WHERE CardNo = @crd;";
            command.Parameters.AddWithValue("@crd", card.CardNo);
            command.Parameters.AddWithValue("@pin", newPin);
            return command;
        }
        public static bool IsCardNumberValid(string cardNo)
        {
            if (cardNo != null && cardNo.Length == CARD_NUMER_LENGTH)
            {
                var chars = cardNo.ToCharArray();
                bool onlyNums = true;
                foreach (char c in chars)
                {
                    if (!char.IsDigit(c))
                    {
                        onlyNums = false;
                        break;
                    }
                }
                return onlyNums;
            }
            return false;
        }

        public static CreditCard CreateCard(SqlDataReader result)
        {
            var CardNo = (string)result["CardNo"];
            var AccountId = (int)result["AccountId"];
            var CustomerId = (int)result["CustomerId"];
            var CardHolder = (string)result["CardHolder"];
            return new CreditCard(CardNo, AccountId, CustomerId, CardHolder);
        }

        public static int GetPin(SqlDataReader result)
        {
            return (int) result["PIN"];
        }

        public static decimal GetBalance(SqlDataReader result)
        {
            return (decimal) result["Balance"];
        }
    }
}
