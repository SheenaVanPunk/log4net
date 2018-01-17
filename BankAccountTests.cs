using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using log4net;
using log4net.Config;
using System.Configuration;
using System.Data.Sql;
using System.Linq;
using System.Data;

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
            log4net.Config.XmlConfigurator.Configure();
            string Name = "Mr. Bryan Walton";
            bool testPassed = true;

            try
            {

                 double beginningBalance = 11.99;
                 double debitAmount = 10; // this value should be changed in order to test all 3 scenarios, debitAmount <0, debitAmount>beginningBalance,debitAmount<beginningBalance
                 double expected = beginningBalance - debitAmount;
                 BankAccount account = new BankAccount(Name, beginningBalance);
            
            // act  
                
                account.Debit(debitAmount);
                double actual = account.Balance;
                Assert.AreEqual(expected, actual, 0.001); 

                if (testPassed) 
                {
                    log.Info("Test succesfully passed, amount of " + debitAmount.ToString() + " is debited from " + beginningBalance .ToString()+ ". New balance is:" + actual.ToString());

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
    }
}
