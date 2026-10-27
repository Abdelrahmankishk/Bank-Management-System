using Bank_Management_System.Models;
using Bank_Management_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Contracts
{
    public interface ICustomerAccount
    {
        public (bool success, string msg) AddCustomerAccount(CustomerAccount account);

        public CustomerAccount GetCustomerAccountByAccountandCutomerIDs(int AccountId, int CustomerID);
        public (bool success, string msg) UpdateAccountStatus(AccountStatus status, int CustomerId, string AccountCode);
    }
}
