using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer hothaifa = new Customer("hothaifa", "0526618010", 314774050);
            Customer nor = new Customer("nor", "05432323232", 315888888);
            Account hothaifsaccount1 = new Account(550, hothaifa);
            Account hothaifsaccount2 = new Account(1515, hothaifa);
            Account hothaifsaccount3 = new Account(19000, hothaifa);
            Account norsaccount1 = new Account(5000, nor);
            Bank mercantile = new Bank();
            mercantile.AddNewCusomer(hothaifa);
            mercantile.OpenNewAccount(hothaifsaccount1, hothaifa);
            mercantile.OpenNewAccount(hothaifsaccount2, hothaifa);
          // Console.WriteLine(mercantile.GetAccountNumber(15));
            Console.WriteLine(mercantile.GetAccountNumber(hothaifsaccount1.AccountNumber));
            Console.WriteLine();
            Console.WriteLine();
            mercantile.XmlfikeCreater();
        }
    }
}
