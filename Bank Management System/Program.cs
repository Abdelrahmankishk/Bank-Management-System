using Bank_Management_System.Contracts;
using Bank_Management_System.Models;
using Bank_Management_System.Services;
using Bank_Management_System.UI;
using ConsoleHelperV2;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new AppDbContext();
            dbContext.Database.Migrate();

            var CustomerService = new CustomerService(dbContext);
            var branchService = new BranchService(dbContext);
            var customerAccountService = new CustomerAccountService(dbContext);
            var accountService = new AccountService(dbContext,branchService,CustomerService,customerAccountService);
            var CustomerUI = new CustomerUI(CustomerService);
            var AccountUI = new AccountUI(accountService);
            MainMenu menu = new(CustomerUI,AccountUI);
            menu.Run();
        }

        

        


        private static void UpdateAccountStatus(AppDbContext db)
        {
            ConsoleHelperV2.ConsoleHelper.PrintSubHeader("Update Account Status");
            var accountNum = ConsoleHelperV2.ConsoleHelper.ReadString("Branch Code (9xxx)         ");
            var Account = db.accounts.FirstOrDefault(a => a.AccountNumber == $"ACC-{accountNum}-2026");
            if (Account == null) {
                ConsoleHelperV2.ConsoleHelper.Error("Account Not Found");
                ConsoleHelperV2.ConsoleHelper.Wait();
                return;
            }
            var customerId = ConsoleHelperV2.ConsoleHelper.ReadInt("Customer Id         ");
            var customer = db.customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                ConsoleHelperV2.ConsoleHelper.Error("Customer Not Found");
                ConsoleHelperV2.ConsoleHelper.Wait();
                return;
            }

            var CustomerAccount = db.customersAccount.FirstOrDefault(ca => ca.accountId == Account.Id &&  ca.customerId == customerId);
            if (CustomerAccount == null) {
                ConsoleHelperV2.ConsoleHelper.Error("The Account is not Owned by this Customer");
                ConsoleHelperV2.ConsoleHelper.Wait();
                return;
            }
            Console.WriteLine("New Status");
            ConsoleHelperV2.ConsoleHelper.Info("1) Active");
            ConsoleHelperV2.ConsoleHelper.Info("2) Closed");
            var OwnershipTypechoice = ConsoleHelperV2.ConsoleHelper.ReadInt("Choice: ", 1, 2);

            Models.Enums.AccountStatus newStatus = OwnershipTypechoice switch { 
                1=> Models.Enums.AccountStatus.Active,
                _ => Models.Enums.AccountStatus.Closed
            };
        }
        
    }
}
