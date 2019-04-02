using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankProject
{
    public class Bank:IBank
    {
        #region  DATA
        private List<Account> accounts=new List<Account>();
        private List<Customer> customers= new List<Customer>();
        private Dictionary<int, Customer> mapCustomerIdToCustomer = new Dictionary<int, Customer>();
        private Dictionary<int, Customer> mapCustomerNumbetToCustomer = new Dictionary<int, Customer>();
        private Dictionary<int, Account> mapAccountNumbeToAccount = new Dictionary<int, Account>();
        private Dictionary<Customer, List<Account>> mapCustomerToAccuntList = new Dictionary<Customer, List<Account>>();
        private int totalMoneyInBank;
        private int profit;
        private int minValue;

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
            Customer cust;
            return mapCustomerIdToCustomer.TryGetValue(cusomerId,out cust)  ? cust : throw new CusomerNotFoundException();
        }
        internal Customer GetCustomerByNumber(int cusomernumber)
        {
            Customer cust;
            return mapCustomerNumbetToCustomer.TryGetValue(cusomernumber, out cust) ? cust : throw new CusomerNotFoundException();
        }
        internal Account GetAccountNumber(int AccountNumber)
        {
            Account acc;
            return mapAccountNumbeToAccount.TryGetValue(AccountNumber, out acc) ? acc : throw new CusomerNotFoundException();
        }
        internal List<Account> GetCustomerById(Customer cust)
        {
            List<Account> acc;
            return mapCustomerToAccuntList.TryGetValue(cust, out acc) ? acc : throw new CusomerNotFoundException();
        }
        internal int GetTotalBalance(Customer cust)
        {
            int custTotalMoneyInBank = 0;
            foreach(Account acc in accounts)
            {

                if (acc.AccountOwner == cust)
                    custTotalMoneyInBank += acc.Balance;
                    
            }
            return custTotalMoneyInBank;
        }
        #endregion
        #region CTOR
        public Bank()
        {
            var maaxMinToTheBank = (from s in accounts where s.MaxMinusAllowed < 0 select s.MaxMinusAllowed).ToList();
             minValue=maaxMinToTheBank.Sum();
        }
        #endregion
        #region FUNCTIONALITY
        internal void AddNewCusomer(Customer cust )
        {
            if (cust != null)
            {
                if (!customers.Contains(cust))
                {
                    customers.Add(cust);
                    mapCustomerIdToCustomer.Add(cust.CustomerID, cust);                
                    mapCustomerNumbetToCustomer.Add(cust.CustomerNumber, cust);
                }
                else
                {
                    throw new CustomerAlreadyExistedException();
                }
            }
            else throw new ArgumentNullException();
        }
        internal void OpenNewAccount(Account acc,Customer cust )
        {
            if (cust != null || acc != null)
            {
                if (!accounts.Contains(acc))
                {
                    int accontWithTheSameCustCounter = 0;
                    accounts.Add(acc);
                    mapAccountNumbeToAccount.Add(acc.AccountNumber, acc);
                    foreach (Account item in accounts)
                    {
                        if (item.AccountOwner == cust)
                        {
                            accontWithTheSameCustCounter++;
                        }
                    }
                    if (accontWithTheSameCustCounter > 1)
                    {
                        mapCustomerToAccuntList[cust].Add(acc);
                    }
                    else
                    {
                        List<Account> firsCustList = new List<Account>();
                        firsCustList.Add(acc);
                        mapCustomerToAccuntList.Add(cust, firsCustList);
                    }
                }
                else
                {
                    throw new AlreadyExistedAcountException();
                }
            }
            else
                throw new ArgumentNullException();
        }
        internal int Withdraw (Account acc , int amount)
        {
            if (totalMoneyInBank - amount < minValue)
                throw new yourBankIsBtokeLikeYourAccountExcepthion();
            else 
                acc.Subtract(amount);
            return acc.Balance;
        
        }
        internal int  Deposit(Account acc1, int amount)
        {
            acc1.Add(amount);
            return acc1.Balance;
        }
        internal void CloseAccount(Account acc, Customer cust)
        {
            accounts.Remove(acc);
            mapAccountNumbeToAccount.Remove(acc.AccountNumber);
            mapCustomerToAccuntList[cust].Remove(acc);
            if (mapCustomerToAccuntList[cust]==null )
            {
                mapCustomerToAccuntList.Remove(cust);
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
                    mapAccountNumbeToAccount.Add(acc.AccountNumber, acc);
                }
                catch (Exception e)
                {
                    throw new CanotOpenAccountException(e.Message);
                }
                try
                {
                    List<Account> custlist = mapCustomerToAccuntList[acc.AccountOwner];
                    mapCustomerToAccuntList.Add(acc.AccountOwner, custlist);
                }
                catch
                {
                    List<Account> newlist = new List<Account>();
                    newlist.Add(acc);
                    mapCustomerToAccuntList.Add(acc.AccountOwner, newlist);
                }
            }
            else
                throw new NotTheSameCustomerException();
        }
        #endregion

        #region XML
        public void XmlfikeCreater()
        {
            BankToXml bankToXml1 = new BankToXml(this.accounts, this.customers, this.totalMoneyInBank);
            XmlSerializer bankXmlSerializer = new XmlSerializer (bankToXml1.GetType());
            using (Stream file = new FileStream(@"c:\temp\Ban1kFile.xml", System.IO.FileMode.Create)) // creating new file stream
            {
                bankXmlSerializer.Serialize(file, bankToXml1);
            }
        }
        #endregion
        
    }
}

