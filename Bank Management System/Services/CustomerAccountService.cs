using Bank_Management_System.Contracts;
using Bank_Management_System.Models;
using Bank_Management_System.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Services
{
    public class CustomerAccountService(AppDbContext dbContext) : ICustomerAccount
    {
        public (bool success, string msg) AddCustomerAccount(CustomerAccount account)
        {
            if (account == null)
                return (false, "Invalid Account");
            dbContext.customersAccount.Add(account);
            dbContext.SaveChanges();

            return (true, $"and linked to customer {account.customerId} as {account.ownershipType} owner");
        }
    }
}
