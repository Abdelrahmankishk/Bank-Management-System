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

            MainMenu.Run(dbContext);
        }

        

        

        //private static void AddAccount(AppDbContext db)
        //{
        //    ConsoleHelperV2.ConsoleHelper.PrintSubHeader("Open New Account");

        //    Console.WriteLine("Account Type");
        //    ConsoleHelperV2.ConsoleHelper.Info("1) Savings");
        //    ConsoleHelperV2.ConsoleHelper.Info("2) Current");
        //    ConsoleHelperV2.ConsoleHelper.Info("3) Business");
        //    var AccountTypreChoice = ConsoleHelperV2.ConsoleHelper.ReadInt("Choice", 1, 3);
        //    var branchCode = ConsoleHelperV2.ConsoleHelper.ReadInt("Branch Code         ");
        //    var branch = db.branches.FirstOrDefault(b=>b.Code == branchCode);
        //    if (branch == null)
        //    {
        //        ConsoleHelperV2.ConsoleHelper.Error("Branch Not Found");
        //        ConsoleHelperV2.ConsoleHelper.Wait();
        //        return;
        //    }
        //    var customerId = ConsoleHelperV2.ConsoleHelper.ReadInt("Customer Id         ");
        //    var customer = db.customers.FirstOrDefault(c=>c.Id == customerId);
        //    if (customer == null) {
        //        ConsoleHelperV2.ConsoleHelper.Error("Customer Not Found");
        //        ConsoleHelperV2.ConsoleHelper.Wait();
        //        return;
        //    }
        //    Console.WriteLine("Ownership Type");
        //    ConsoleHelperV2.ConsoleHelper.Info("1) Primary");
        //    ConsoleHelperV2.ConsoleHelper.Info("2) CoHolder");
        //    var OwnershipTypechoice = ConsoleHelperV2.ConsoleHelper.ReadInt("Choice: ",1,2);

        //    var newAccount = new Models.Account()
        //    {
        //        AccountNumber = $"ACC-{Account.counter++}-2026",
        //        accountType = (Models.Enums.AccountType)AccountTypreChoice,
        //        CurrentBalance = 0,
        //        BranchId = branch.Code,
        //        OpeningDate = DateTime.Now,
        //    };
        //    db.accounts.Add(newAccount);

        //    var newCustomerAccount = new Models.CustomerAccount() { 
        //        customer  = customer,
        //        account = newAccount,
        //        accountStatus = Models.Enums.AccountStatus.Active,
        //        OwnerShipDate = DateTime.Now,
        //        ownershipType = (Models.Enums.OwnershipType)OwnershipTypechoice
        //    };
        //    db.customersAccount.Add(newCustomerAccount);

        //    db.SaveChanges();

        //    ConsoleHelperV2.ConsoleHelper.Success($"Account '{newAccount.AccountNumber}' created and linked to customer {customer.Id} as {newCustomerAccount.ownershipType} owner");
        //    ConsoleHelperV2.ConsoleHelper.Wait();


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
