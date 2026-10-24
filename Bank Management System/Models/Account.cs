using Bank_Management_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models;

    public class Account
    {
    public int Id { get; set; }
    public string AccountNumber { get; set; } = default!;
    public double CurrentBalance { get; set; }
    public AccountType accountType { get; set; }
    public DateTime OpeningDate { get; set; }
}

