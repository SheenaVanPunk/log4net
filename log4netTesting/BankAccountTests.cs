using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using log4net;
using log4net.Config;
using System.Configuration;
using System.Data.Sql;
using System.Linq;
using System.Data;
using System.IO;
using System.Text;


namespace BankTest
{
    [TestClass]
    public class BankAccountTests
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //DataSet1.CustomerDataTable table = new DataSet1TableAdapters.CustomerTableAdapter().GetData();          
        //double debitAmount = Convert.ToDouble( table.Rows[0]["balance"].ToString());
        // Name = table.Rows[0]["customerName"].ToString();

        [TestMethod]
        public void Debit_Test()
        {
            // arrange  
            log4net.Config.XmlConfigurator.Configure(); // komanda koja ispisuje logove u eksternom tekstualnom fajlu
            string Name = "Pavle Pavlovic";
            bool testPassed = true;

            try
            {

                double beginningBalance = 11.99;
                double debitAmount = 9; // this value should be changed in order to test all 3 scenarios, debitAmount <0, debitAmount>beginningBalance,debitAmount<beginningBalance
                double expected = beginningBalance - debitAmount;
                BankAccount account = new BankAccount(Name, beginningBalance);

                // act  

                account.Debit(debitAmount);
                double actual = account.Balance;
                Assert.AreEqual(expected, actual, 0.001);

                if (testPassed)
                {
                    log.Info("Test succesfully passed, amount of " + debitAmount.ToString() + " is debited from " + beginningBalance.ToString() + ". New balance is:" + actual.ToString());

                }


            }
            catch (ArgumentOutOfRangeException e)
            {

                log.Error("Customer: " + Name + "-" + e.Message.ToString());
                Assert.Fail();
                testPassed = false;
                //return;
            }
            catch (Exception e)
            {

                log.Error("Trace: " + e.Message.ToString());
                Assert.Fail();
                testPassed = false;
                //return;
            }

        }


        [TestMethod]
        public void Expenses_Test()
        {
            log4net.Config.XmlConfigurator.Configure();
            string Name = "Olga Cukucan";
            bool testPassed = true;
            try
            {
                double balance = 300;
                double creditAmount = -20;
                double expected = balance + (creditAmount - creditAmount * 0.1);
                BankAccount bnkacc = new BankAccount(Name, balance);

                bnkacc.Expenses(creditAmount);
                double actual = bnkacc.Balance;
                Assert.AreEqual(expected, actual, 0.001);

                if (testPassed)
                {
                    log.Info("Test passed, the amount of credit " + creditAmount.ToString() + " has been successfully added to the beginning balance of " + balance.ToString() + ". New balance is now " + actual.ToString() + ".");

                }

            }
            catch (ArgumentOutOfRangeException a)
            {

                log.Error("Customer: " + Name + " - " + a.Message.ToString() + ". It is impossible to add negative credit amount to a bank account.");
                Assert.Fail();
                testPassed = false;
            }
        }

        [TestMethod]
        public void BalanceCheck_Test()
        {
            log4net.Config.XmlConfigurator.Configure();
            string Name = "Olga Cukucan";
            bool testPassed = true;


            try
            {

                double beginningBalance = 700;
                double debitAmount = -634;
                double expected = beginningBalance - debitAmount;

                if (expected > 100 && expected < 500)
                {
                    expected += 500;
                    log.Info("The new balance after the 500 bonus is: " + expected.ToString());

                }

                BankAccount bnk = new BankAccount(Name, beginningBalance);

                double actual = bnk.BalanceCheck(debitAmount);
                Assert.AreEqual(expected, actual, 0.001);

                if (testPassed)
                {
                    log.Info("The amount of " + debitAmount.ToString() + " was debitted from bank account. New balance is: " + actual + "."); // poruka kad prodje test se upise u ovom redu     
                }
            } 

            catch (ArgumentOutOfRangeException e)
            {

                log.Error("Customer: " + Name + "-" + e.Message.ToString());
                Assert.Fail();
                testPassed = false;

            }
            catch (Exception e)
            {

                log.Error("Trace: " + e.Message.ToString());
                Assert.Fail();
                testPassed = false;

            }

        }

    }

}




