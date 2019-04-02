using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankProject
{
    public class BankToXml
    {
        public List<Account> _accounts;
        public List<Customer> _customers;
        public int _totalbalance;

        public BankToXml(List<Account> accounts, List<Customer> customers, int totalbalance)
        {
            _accounts = accounts;
            _customers = customers;
            _totalbalance = totalbalance;
        }

        public BankToXml()
        {
                
        }
        

    }
}
