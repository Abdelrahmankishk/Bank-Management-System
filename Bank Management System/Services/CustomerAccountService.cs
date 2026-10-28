using Bank_Management_System.Contracts;
using Bank_Management_System.Models;
using Bank_Management_System.Models.Enums;
using Bank_Management_System.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Services
{
    public class CustomerAccountService(AppDbContext dbContext,ICustomer customerService) : ICustomerAccount
    {
        public (bool success, string msg) AddCustomerAccount(CustomerAccount account)
        {
            if (account == null)
                return (false, "Invalid Account");
            dbContext.customersAccount.Add(account);
            dbContext.SaveChanges();

            return (true, $"and linked to customer {account.customerId} as {account.ownershipType} owner");
        }

        public CustomerAccount GetCustomerAccountByAccountandCutomerIDs(int AccountId, int CustomerID) => dbContext.customersAccount.FirstOrDefault(ca => ca!.customerId == CustomerID && ca.accountId == AccountId);

       

        public (bool success, string msg) UpdateAccountStatus(AccountStatus status, int CustomerId, string AccountCode)
        {
            var customer = customerService.GetCusotmerById(CustomerId);
            if (customer == null)
                return (false, "Customer Not Found");

            var account = dbContext.accounts.FirstOrDefault(a => a.AccountNumber == $"ACC-{AccountCode}-2026");
            if (account == null) return (false, "Account Not Found");

            var CustomerAccount = GetCustomerAccountByAccountandCutomerIDs(account.Id, customer.Id);
            if (CustomerAccount == null) return (false, $"Account '{account.AccountNumber}' does not belong to Customer ");

            CustomerAccount.accountStatus = status;
            dbContext.SaveChanges();
            return (true, $"Status Updated");
        }

        public (bool success, string msg) RemoveAccountFromCustomer(int CustomerId, string AccountCode)
        {
            var customer = customerService.GetCusotmerById(CustomerId);
            if (customer == null)
                return (false, "Customer Not Found");

            var account = dbContext.accounts.FirstOrDefault(a => a.AccountNumber == $"ACC-{AccountCode}-2026");
            if (account == null) 
                return (false, "Account Not Found");

            var CustomerAccount = GetCustomerAccountByAccountandCutomerIDs(account.Id, customer.Id);
            if (CustomerAccount == null) 
                return (false, $"Account '{account.AccountNumber}' does not belong to Customer ");

            dbContext.customersAccount.Remove(CustomerAccount);
            dbContext.SaveChanges();
            if(!dbContext.customersAccount.Any(ca=>ca.accountId == account.Id))
            {
                dbContext.accounts.Remove(account);
                dbContext.SaveChanges();
                return (true, $@"Ownership link deleted.
That was the last owner - account '{account.AccountNumber}' is deleted");
            }
            return (true, $" Ownership link deleted");
        }
    }
}
