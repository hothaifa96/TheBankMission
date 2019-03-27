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
        private static int _NumberOfAcc = 0;
        private readonly int _accountNumber;
        private readonly Customer _accontOwner;
        private int _maxMinusAllowed;

        #region prop's
        public int AccountNumber{ get; set; }
        public int Balance { get; internal set; }
        public Customer AccountOwner { get { return _accontOwner; } }
        public int MaxMinusAllowed { get { return _maxMinusAllowed; } }
        #endregion

        #endregion
        public Account(int monthlyIncome, Customer owner)
        {
            _maxMinusAllowed = monthlyIncome * -3;
            _accontOwner = owner;
            _accountNumber = _NumberOfAcc++;
            AccountNumber = _NumberOfAcc++;

            Balance = 0;
        }
        #region Ctor's



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
            Account acc = x;
            if (x.AccountOwner == y.AccountOwner)
                acc.Balance += y.Balance;
            else
                throw new ArgumentNullException();
            return x;

        }
        #endregion
        #region funcounaliuty 
        public void Add(int amount)
        {
            Balance += amount;
        }
        public void Subtract (int amount)
        {
            Balance -= amount;
        }

        public override string ToString()
        {
            return $" the owner is {AccountOwner} the account number is { AccountNumber} balance is {Balance}";
        }
        #endregion

    }
}
