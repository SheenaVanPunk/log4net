using System;

namespace BankAccountNS
{
    /// <summary>   
    /// Bank Account demo class.   
    /// </summary>   
    public class BankAccount
    {
        private string m_customerName;

        private double m_balance;

       
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private BankAccount()
        {
        }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
            
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        

        public void Debit(double amount)
        {

            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }  

           // m_balance += amount; // intentionally incorrect code  
            m_balance -= amount;  
        }

        public void Credit(double amount)
        {

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
            
        }


        public static void Main()
        {
            //BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);
            //ba.Credit(5.77);
            //ba.Debit(11.22);
            //Console.WriteLine("Current balance is ${0}", ba.Balance);
        }

        public void Expenses(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            m_balance += amount - (amount * 0.1);
       
        }

        public void BalanceCheck(double amount, double newBalance)
        {
            double n_balance = newBalance;
            n_balance = m_balance - amount;
            
            if (n_balance > 500)
            {
                
                Console.WriteLine("New balance is: {0}", n_balance);
            }
                if (n_balance <= 100 && n_balance<0)
                {
                throw new ArgumentOutOfRangeException(n_balance.ToString());
                }  
            
            else
            {
                n_balance = m_balance + 500;
                Console.WriteLine("None of the previous conditions is fulfilled, the balance increased for 500.");
            }

          
        }
    }
}
