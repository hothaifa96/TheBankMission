using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class Bank:IBank
    {
        #region  DATA
        private List<Account> accounts=new List<Account>();
        private List<Customer> customers= new List<Customer>();
        private Dictionary<int, Customer> customerIdKey = new Dictionary<int, Customer>();
        private Dictionary<int, Customer> customerNumberkey = new Dictionary<int, Customer>();
        private Dictionary<int, Account> accountNumberkey = new Dictionary<int, Account>();
        private Dictionary<Customer, List<Account>> customerListKey = new Dictionary<Customer, List<Account>>();
        private int totalMoneyInBank;
        private int profit;

        public string Name
        {
            get;set;
        }

        public string Address 
        {
            get; set;
        }

        public int CustomerCount 
        {
            get; set;
        }
        #endregion

        #region GETTER's
        internal Customer GetCustomerById(int cusomerId)
        {
            return customerIdKey[cusomerId] == null ? customerIdKey[cusomerId] : throw new CusomerNotFoundException();
        }
        internal Customer GetCustomerByNumber(int cusomernumber)
        {
            return customerNumberkey[cusomernumber] == null ? customerNumberkey[cusomernumber] : throw new CusomerNotFoundException();
        }
        internal Account GetAccountNumber(int AccountNumber)
        {
            return accountNumberkey[AccountNumber] != null ? accountNumberkey[AccountNumber] : throw new AccountNotFoundException();
        }
        internal List<Account> GetCustomerById(Customer cust)
        {
            return customerListKey[cust] == null ? customerListKey[cust] : throw new AccountNotFoundException();
        }
        internal int GetTotalBalance(Account acc)
        {
            totalMoneyInBank = acc.Balance;
            return totalMoneyInBank;
        }
        #endregion

        #region FUNCTIONALITY
        internal void AddNewCusomer(Customer cust )
        {
            if (cust != null)
            {
                customers.Add(cust);
                try
                {
                    customerIdKey.Add(cust.CustomerID, cust);
                }
                catch (Exception e)
                {
                    throw new CustomerIdAlreadyExistedException();
                }
                try
                {
                    customerNumberkey.Add(cust.CustomerNumber, cust);
                }
                catch (Exception)
                {
                    throw new CustomerIdAlreadyExistedException();
                }
            }
            else throw new ArgumentNullException();
        }
        internal void OpenNewAccount(Account acc,Customer cust )
        {
            if( cust!=null&&acc!=null)
            {
                accounts.Add(acc);
                try
                {
                    accountNumberkey.Add(acc.AccountNumber, acc);
                    Console.WriteLine("acoount list added succesfuly");
                }
                catch(Exception e)
                {
                    throw new CanotOpenAccountException(e.Message);
                }
                try
                {
                    customerListKey[cust].Add(acc);
                    Console.WriteLine("acoount listkey added succesfuly");
                }
                catch
                {
                    List<Account> newcustlist = new List<Account>();
                    newcustlist.Add(acc);
                    customerListKey.Add(cust, newcustlist);
                }// if this customer have a list of accounts so we will add this new account to the list else we going to create new list and insert this list to Dictionary
            }
        }
        internal int Deposit (Account acc , int amount)
        {
           /* totalMoneyInBank += amount;*/
            acc.Balance = totalMoneyInBank + amount;
            return acc.Balance;
        }
        internal int Withdraw (Account acc1, int amount)
        {
            int mincheck = totalMoneyInBank - amount+acc1.Balance;
            if (mincheck > acc1.MaxMinusAllowed)
            {
                acc1.Balance = mincheck;
                return acc1.Balance;
            }
            else
                throw new BalanceException();
        }
        internal void CloseAccount(Account acc, Customer cust)
        {
            accounts.Remove(acc);
            accountNumberkey.Remove(acc.AccountNumber);
            customerListKey[cust].Remove(acc);
            if (customerListKey[cust]==null )
            {
                customerListKey.Remove(cust);
            }
        }
        internal void ChargeAnnualCommission( float percentage )
        {
            if (totalMoneyInBank >= 0)
            {
                profit = Convert.ToInt32(totalMoneyInBank * percentage);
                totalMoneyInBank -= profit;
            }
            else
                profit = Convert.ToInt32(totalMoneyInBank * (2 * percentage));
        }
        internal void JoinAccounts(Account acc1, Account acc2)
        {
            if (acc1.AccountOwner == acc1.AccountOwner)
            {
                Account acc = acc1 + acc2;
                CloseAccount(acc1, acc1.AccountOwner);
                CloseAccount(acc2, acc2.AccountOwner);
                accounts.Add(acc);
                try
                {
                    accountNumberkey.Add(acc.AccountNumber, acc);
                }
                catch (Exception e)
                {
                    throw new CanotOpenAccountException(e.Message);
                }
                try
                {
                    List<Account> custlist = customerListKey[acc.AccountOwner];
                    customerListKey.Add(acc.AccountOwner, custlist);
                }
                catch
                {
                    List<Account> newlist = new List<Account>();
                    newlist.Add(acc);
                    customerListKey.Add(acc.AccountOwner, newlist);
                }
            }
            else
                throw new NotTheSameCustomerException();
        }

        #endregion
    }
}

