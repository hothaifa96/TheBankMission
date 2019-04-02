using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class Account
    {
        #region DATA
        private static int _NumberOfAcc = 1;
        private readonly int _accountNumber;
        private readonly Customer _accontOwner;
        private int _maxMinusAllowed;

        #region prop's
        public int AccountNumber{ get; set; }
        public int Balance { get;  set; }
        public Customer AccountOwner { get { return _accontOwner; } }
        public int MaxMinusAllowed { get { return _maxMinusAllowed; } }
        #endregion

        #endregion

        #region Ctor's

        public Account(int monthlyIncome, Customer owner)
        {
            _maxMinusAllowed = monthlyIncome * -3;
            _accontOwner = owner;
            _accountNumber = _NumberOfAcc++;
            AccountNumber = _NumberOfAcc++;

            Balance = 0;
        }
        public Account()
        {

        }

        #endregion
        #region overrides
        public static bool operator ==(Account x, Account y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return (x.AccountNumber == y.AccountNumber);
        }
        public static bool operator !=(Account x, Account y)
        {
            return !(x == y);
        }

        public override bool Equals(object obj)
        {
            Account cust = obj as Account;
            return this == cust;
        }

        public override int GetHashCode()
        {
            return this._accountNumber;
        }
        

        public static Account operator +(Account x, Account y)
        {
            if (x.AccountOwner == y.AccountOwner)
            {
                int deluxedMonthlyIncome = ((x.MaxMinusAllowed / (-3)) + (y.MaxMinusAllowed / (-3)));
                Account newAccount = new Account(deluxedMonthlyIncome, x.AccountOwner);//the tow accounts hbave the same owner so we can also rite y.accounOwner
                newAccount.Balance=x.Balance+ y.Balance;
            return newAccount;
            }
            else
                throw new ArgumentNullException();
            

        }
        #endregion
        #region funcounaliuty 
        public void Add(int amount)
        {
            Balance += amount;
        }
        public void Subtract (int amount)
        {
            Balance -= (Balance - amount > MaxMinusAllowed ? amount : throw new youHaveReachedTheMaxMinAllowedException());
            
        }

        public override string ToString()
        {
            return $" the owner is {AccountOwner} the account number is { AccountNumber} balance is {Balance}";
        }

        public static int operator +(Account acc, int y)
        {
            
            return acc.Balance + y;
        }
        public static int operator -(Account  acc, int y)
        {
            if (acc.Balance-y < acc.MaxMinusAllowed)
                throw new BalanceException();
            else 
                return acc.Balance - y;
        }

        #endregion

    }
}
