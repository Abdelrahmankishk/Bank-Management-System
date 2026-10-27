using Bank_Management_System.Contracts;
using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Services
{
    public class AccountService(AppDbContext dbContext, IBranch branch, ICustomer customer,ICustomerAccount customerAccountService) : IAccount
    {
        public (bool success, string msg) AddAccount(Account account, CustomerAccount customerAccount)
        {
            var AccountBranch = branch.GetBracnhByCode(account.BranchId);
            if (AccountBranch is null)
                return (false, "Branch Not Found");
            var AccountCustomer = customer.GetCusotmerById(customerAccount.customerId);
            if (AccountCustomer is null)
                return (false, "Customer Not Found");

            dbContext.accounts.Add(account);
            dbContext.SaveChanges();

            var CustomerAccountAddStatus=customerAccountService.AddCustomerAccount(customerAccount);
            if (CustomerAccountAddStatus.success == false)
                return (false, "Error; Can not add Account to the customer");

            return (true, $"Account '{account.AccountNumber}' created {CustomerAccountAddStatus.msg}");
        }

        public int getNextAccountId() => dbContext.accounts.Count();

    }
}