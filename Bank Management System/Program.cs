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
                MainMenu();
                int choice = ConsoleHelperV2.ConsoleHelper.ReadInt("Enter choice: ",0,5);
                switch (choice) {
                    case 1:
                        break;
                    case 2:
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
    }
}
