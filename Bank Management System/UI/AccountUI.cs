using Bank_Management_System.Contracts;
using Bank_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.UI
{
    public class AccountUI(IAccount accountService) : IAccountDisplay
    {
        public void ShowAddNewAccountuccess()
        {
            var newAccount = GetAccountData();

            if (newAccount.success == true)
            {
                var AddingAcountResult = accountService.AddAccount(newAccount.newAccount, newAccount.newCustomerAccount);
                if (AddingAcountResult.success == false)
                {
                    ConsoleHelperV2.ConsoleHelper.Error(AddingAcountResult.msg);
                    return;
                }
                ConsoleHelperV2.ConsoleHelper.Success(AddingAcountResult.msg);
            }

        }

        private (bool success, Account newAccount, CustomerAccount newCustomerAccount) GetAccountData()
        {
            ConsoleHelperV2.ConsoleHelper.PrintSubHeader("Open New Account");

            Console.WriteLine("Account Type");
            ConsoleHelperV2.ConsoleHelper.Info("1) Savings");
            ConsoleHelperV2.ConsoleHelper.Info("2) Current");
            ConsoleHelperV2.ConsoleHelper.Info("3) Business");
            var AccountTypreChoice = ConsoleHelperV2.ConsoleHelper.ReadInt("Choice", 1, 3);
            var branchCode = ConsoleHelperV2.ConsoleHelper.ReadInt("Branch Code");

            var customerId = ConsoleHelperV2.ConsoleHelper.ReadInt("Customer Id");

            Console.WriteLine("Ownership Type");
            ConsoleHelperV2.ConsoleHelper.Info("1) Primary");
            ConsoleHelperV2.ConsoleHelper.Info("2) CoHolder");
            var OwnershipTypechoice = ConsoleHelperV2.ConsoleHelper.ReadInt("Choice: ", 1, 2);

            int AccountNextID = accountService.getNextAccountId() + 1;
            var newAccount = new Models.Account()
            {
                AccountNumber = $"ACC-{(9000 + AccountNextID)}-2026",
                accountType = (Models.Enums.AccountType)AccountTypreChoice,
                CurrentBalance = 0,
                BranchId = branchCode,
                OpeningDate = DateTime.Now,
            };
            var newCustomerAccount = new Models.CustomerAccount()
            {
                customerId = customerId,
                account = newAccount,
                accountStatus = Models.Enums.AccountStatus.Active,
                OwnerShipDate = DateTime.Now,
                ownershipType = (Models.Enums.OwnershipType)OwnershipTypechoice
            };


            return (true, newAccount, newCustomerAccount);

        }
    }
}

