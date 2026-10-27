using Bank_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Contracts;

    public interface ICustomer
    {
    public (bool success, string msg) AddCustomer(Customer customer);

    public Customer GetCusotmerById(int id);
    }
