using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new AppDbContext();
            dbContext.Database.Migrate();

            bool isExit = true;
            while (isExit) {
                Console.Clear();
                MainMenu();
                int choice = ConsoleHelperV2.ConsoleHelper.ReadInt("Enter choice ",0,5);
                switch (choice) {
                    case 1:
                        AddCustomer(dbContext);
                        break;
                    case 2:
                        AddAccount(dbContext);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 0:
                        isExit = false;
                        break;
                }
            }
        }

        private static void MainMenu()
        {
            ConsoleHelperV2.ConsoleHelper.PrintHeader("National Bank - Management");
            ConsoleHelperV2.ConsoleHelper.Info("1) Add a new Customer");
            ConsoleHelperV2.ConsoleHelper.Info("2) Open a new Account for a Customer");
            ConsoleHelperV2.ConsoleHelper.Info("3) Update Account Status (Active/Closed)");
            ConsoleHelperV2.ConsoleHelper.Info("4) Remove an Account from a Customer");
            ConsoleHelperV2.ConsoleHelper.Info("5) List all Customers (with accounts)");
            ConsoleHelperV2.ConsoleHelper.Info("0) Exit");
            Console.WriteLine("=====================================================");
        }

        private static void AddCustomer(AppDbContext db)
        {
            ConsoleHelperV2.ConsoleHelper.PrintSubHeader("Add New Customer");
            var Name = ConsoleHelperV2.ConsoleHelper.ReadString("Full Name         ");
            var NationalId = ConsoleHelperV2.ConsoleHelper.ReadString("National ID         ");

            if (NationalId.Length != 14 || !NationalId.All(char.IsDigit)) 
            {
                ConsoleHelperV2.ConsoleHelper.Error("National Id must be 14 digit");
                ConsoleHelperV2.ConsoleHelper.Wait();
                return;
            }
            var CheckRepeatedNationalID = db.customers.Any(c => c.NationalID == NationalId);
            if (CheckRepeatedNationalID) {
                ConsoleHelperV2.ConsoleHelper.Error("National Id is already located for Customer");
                ConsoleHelperV2.ConsoleHelper.Wait();
                return;
            }

            var DateOfBirth = ReadDate("National ID (yyyy-MM-dd)         ");

            var Email = ConsoleHelperV2.ConsoleHelper.ReadString("Email         ");

            var Phone = ConsoleHelperV2.ConsoleHelper.ReadString("Phone         ");
            if (!Phone.All(char.IsDigit))
            {
                ConsoleHelperV2.ConsoleHelper.Error("Enter a valid Phone");
                ConsoleHelperV2.ConsoleHelper.Wait();
                return;
            }
            var Address = ConsoleHelperV2.ConsoleHelper.ReadString("Address         ",true);

            Console.WriteLine( "Customer Type");
            ConsoleHelperV2.ConsoleHelper.Info("1) Individual");
            ConsoleHelperV2.ConsoleHelper.Info("2) Business");
            var choice = ConsoleHelperV2.ConsoleHelper.ReadInt("Choice", 1, 2);
            var newCustomer = new Models.Customer()
            {
                FullName = Name,
                NationalID = NationalId,
                PhoneNumber =Phone,
                DateOfBirth = DateOfBirth,
                Email = Email,
                Address = Address,
                Type = choice == 1 ? Models.Enums.CustomerType.Individual : Models.Enums.CustomerType.Organization
            };

            db.customers.Add(newCustomer);
            db.SaveChanges();
            ConsoleHelperV2.ConsoleHelper.Success($"Customer created successfully, CustomerId = {newCustomer.Id}");
            ConsoleHelperV2.ConsoleHelper.Wait();
        }

        private static void AddAccount(AppDbContext db)
        {
            ConsoleHelperV2.ConsoleHelper.PrintSubHeader("Open New Account");

            Console.WriteLine("Account Type");
            ConsoleHelperV2.ConsoleHelper.Info("1) Savings");
            ConsoleHelperV2.ConsoleHelper.Info("2) Current");
            ConsoleHelperV2.ConsoleHelper.Info("3) Business");
            var AccountTypreChoice = ConsoleHelperV2.ConsoleHelper.ReadInt("Choice", 1, 3);
            var branchCode = ConsoleHelperV2.ConsoleHelper.ReadInt("Branch Code         ");
            var branch = db.branches.FirstOrDefault(b=>b.Code == branchCode);
            if (branch == null)
            {
                ConsoleHelperV2.ConsoleHelper.Error("Branch Not Found");
                ConsoleHelperV2.ConsoleHelper.Wait();
                return;
            }
            var customerId = ConsoleHelperV2.ConsoleHelper.ReadInt("Customer Code         ");
            var customer = db.customers.FirstOrDefault(c=>c.Id == customerId);
            if (customer == null) {
                ConsoleHelperV2.ConsoleHelper.Error("Customer Not Found");
                ConsoleHelperV2.ConsoleHelper.Wait();
                return;
            }
            Console.WriteLine("Ownership Type");
            ConsoleHelperV2.ConsoleHelper.Info("1) Primary");
            ConsoleHelperV2.ConsoleHelper.Info("2) CoHolder");
            var OwnershipTypechoice = ConsoleHelperV2.ConsoleHelper.ReadInt("Choice: ",1,2);

            var newAccount = new Models.Account()
            {
                AccountNumber = $"ACC-{Account.counter++}-2026",
                accountType = (Models.Enums.AccountType)AccountTypreChoice,
                CurrentBalance = 0,
                BranchId = branch.Code,
                OpeningDate = DateTime.Now,
            };
            db.accounts.Add(newAccount);

            var newCustomerAccount = new Models.CustomerAccount() { 
                customer  = customer,
                account = newAccount,
                accountStatus = Models.Enums.AccountStatus.Active,
                OwnerShipDate = DateTime.Now,
                ownershipType = (Models.Enums.OwnershipType)OwnershipTypechoice
            };
            db.customersAccount.Add(newCustomerAccount);

            db.SaveChanges();

            ConsoleHelperV2.ConsoleHelper.Success($"Account '{newAccount.AccountNumber}' created and linked to customer {customer.Id} as {newCustomerAccount.ownershipType} owner");
            ConsoleHelperV2.ConsoleHelper.Wait();

        }

        private static DateOnly ReadDate(string message)
        {
            DateOnly value;

            while (true)
            {
                Console.Write($"\n  {message}");
                string ? input = Console.ReadLine();

                if (DateOnly.TryParse(input, out value))
                {
                    return value;
                }

                Console.WriteLine("Invalid date. Please use yyyy-MM-dd format.");
            }
        }
    }
}
