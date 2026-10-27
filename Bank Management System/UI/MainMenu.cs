using Bank_Management_System.Contracts;
using ConsoleHelperV2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.UI
{
    public class MainMenu(ICustomerDisplay customerDisplay, IAccountDisplay accountDisplay , ICustomerAccountDisplay customerAccountDisplay)
    {
        
        public void Run()
        {
            bool isExit = true;
            while (isExit)
            {
                Console.Clear();
                ConsoleHelperV2.ConsoleHelper.PrintHeader("National Bank - Management");
                ConsoleHelperV2.ConsoleHelper.Info("1) Add a new Customer");
                ConsoleHelperV2.ConsoleHelper.Info("2) Open a new Account for a Customer");
                ConsoleHelperV2.ConsoleHelper.Info("3) Update Account Status (Active/Closed)");
                ConsoleHelperV2.ConsoleHelper.Info("4) Remove an Account from a Customer");
                ConsoleHelperV2.ConsoleHelper.Info("5) List all Customers (with accounts)");
                ConsoleHelperV2.ConsoleHelper.Info("0) Exit");
                Console.WriteLine("=====================================================");
                int choice = ConsoleHelperV2.ConsoleHelper.ReadInt("Enter choice ", 0, 5);
                switch (choice)
                {
                    case 1:
                        customerDisplay.ShowAddNewCustomerSuccess();
                        ConsoleHelper.Wait();
                        break;
                    case 2:
                        accountDisplay.ShowAddNewAccountuccess();
                        ConsoleHelper.Wait();
                        break;
                    case 3:
                        customerAccountDisplay.ShowUpdateAccountStatusSuccess();
                        ConsoleHelper.Wait();
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
    }
}
