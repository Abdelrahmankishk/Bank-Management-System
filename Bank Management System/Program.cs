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

            var customerAccountService = new CustomerAccountService(dbContext, CustomerService);
            var accountService = new AccountService(dbContext,branchService,CustomerService,customerAccountService);
            var CustomerUI = new CustomerUI(CustomerService);
            var AccountUI = new AccountUI(accountService);
            var CustomerAccount = new CustomerAccountUI(customerAccountService);
            MainMenu menu = new(CustomerUI,AccountUI, CustomerAccount);
            menu.Run();
        }

        

        


       
            
       
        
    }
}
