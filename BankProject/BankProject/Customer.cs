using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class Customer
    {
        #region DATA
        private static int numOfCust = 0;
        private readonly int customerid;
        private readonly int customerNumber;

        #region prop's 
        public string Name { get; private set; }
        public string PhNumber { get; private set; }
        public int  CustomerID { get;}
        public int CustomerNumber { get; set; }

        #endregion

        #endregion
        #region Ctor's

        public Customer(string name, string phNumber, int cusomerId)
        {
            Name = name;
            PhNumber = phNumber;
            CustomerID = cusomerId;
            CustomerNumber = numOfCust++;
        }
        #endregion
        #region Overrides

        public static bool operator ==(Customer x, Customer y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            
            return (x.CustomerNumber == y.CustomerNumber);
        }
        public static bool operator !=(Customer x, Customer y)
        {
            return !(x== y);
        }

        public override bool Equals(object obj)
        {
            Customer cust = obj as Customer;
            return this==cust;
        }

        public override int GetHashCode()
        {
            return this.CustomerNumber;
        }

        public override string ToString()
        {
            return $"owner name : {Name} phone {PhNumber}";
        }

        #endregion

    }
}
