using Bank_Management_System.Contracts;
using Bank_Management_System.Extentions;
using Bank_Management_System.Models;
using Bank_Management_System.Services;
using ConsoleHelperV2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.UI;

    public  class CustomerUI(ICustomer customerService) : ICustomerDisplay
{

    public void ShowAddNewCustomerSuccess()
    {
        
        var newCustomer = GetCustomer();
        if(newCustomer.success == false)
        {
            ConsoleHelper.Error(newCustomer.msg);
            return;
        }
        var (success, msg) = customerService.AddCustomer(newCustomer.customer);
        if(success)
            ConsoleHelper.Success(msg);
        else
            ConsoleHelper.Error(msg);
    }
    private (bool success,string msg,Customer customer) GetCustomer()
    {
        ConsoleHelper.PrintHeader("Add New Customer");
        var Name = ConsoleHelper.ReadString("Full Name         ");
        var NationalId = ConsoleHelper.ReadString("National ID         ");

        if (!NationalId.IsValidNationalID())
        {
            string msg = "National Id must be 14 digit";
            return (false,msg,default!);
        }

        var DateOfBirth = ConsoleHelperV2.ConsoleHelper.ReadDateOnly("National ID (yyyy-MM-dd)         ");

        var Email = ConsoleHelperV2.ConsoleHelper.ReadString("Email         ");

        var Phone = ConsoleHelperV2.ConsoleHelper.ReadString("Phone         ");
        if (!Phone.IsValidPhone())
        {
            string msg="Enter a valid Phone";
            return (false,msg,default!);
        }
        var Address = ConsoleHelperV2.ConsoleHelper.ReadString("Address         ", true);

        Console.WriteLine("Customer Type");
        ConsoleHelperV2.ConsoleHelper.Info("1) Individual");
        ConsoleHelperV2.ConsoleHelper.Info("2) Business");
        var choice = ConsoleHelperV2.ConsoleHelper.ReadInt("Choice", 1, 2);

        var newCustomer = new Models.Customer()
        {
            FullName = Name,
            NationalID = NationalId,
            PhoneNumber = Phone,
            DateOfBirth = DateOfBirth,
            Email = Email,
            Address = Address,
            Type = choice == 1 ? Models.Enums.CustomerType.Individual : Models.Enums.CustomerType.Organization
        };
        return (true,"New Customer is Created Successfully",newCustomer);
    }
    }

