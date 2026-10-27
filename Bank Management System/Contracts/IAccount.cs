using Bank_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Contracts;

    public interface IAccount
    {
   public (bool success, string msg) AddAccount(Account account,CustomerAccount customerAccount);

    public int getNextAccountId();
}

