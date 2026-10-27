using Bank_Management_System.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.UI
{
    public class CustomerAccountUI(ICustomerAccount customerAccountSerivce) : ICustomerAccountDisplay
    {
        public void ShowUpdateAccountStatusSuccess()
        {
            ConsoleHelperV2.ConsoleHelper.PrintSubHeader("Update Account Status");
            var accountNum = ConsoleHelperV2.ConsoleHelper.ReadString("Branch Code (9xxx");
            var customerId = ConsoleHelperV2.ConsoleHelper.ReadInt("Customer Id");

            Console.WriteLine("New Status");
            ConsoleHelperV2.ConsoleHelper.Info("1) Active");
            ConsoleHelperV2.ConsoleHelper.Info("2) Closed");
            var OwnershipTypechoice = ConsoleHelperV2.ConsoleHelper.ReadInt("Choice: ", 1, 2);

            (Models.Enums.AccountStatus Newstatus, string  status) newStatus = OwnershipTypechoice switch
            {
                1 => (Models.Enums.AccountStatus.Active, "Active"),
                _ => (Models.Enums.AccountStatus.Closed, "Closed")
            };
            bool check = ConsoleHelperV2.ConsoleHelper.Confirm($"Changing Account status to {newStatus.status}");
            if (check == false) {
                ConsoleHelperV2.ConsoleHelper.Warning("Status is Not Changed");
                return;
            }
            var UpdateResult=customerAccountSerivce.UpdateAccountStatus(newStatus.Newstatus, customerId, accountNum);
            if (UpdateResult.success == false)
            {
                ConsoleHelperV2.ConsoleHelper.Error(UpdateResult.msg + $"{customerId}");
                return;
            }
            ConsoleHelperV2.ConsoleHelper.Success($"Status Updated to {UpdateResult.msg}");
        }
    }
}
