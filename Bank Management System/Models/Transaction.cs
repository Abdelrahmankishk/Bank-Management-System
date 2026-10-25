using Bank_Management_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models;

    public class Transaction
    {
    public int TransactionNumber { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public string? Note { get; set; }
    public TransactionType Type { get; set; }
    public int AccountId { get; set; }
    public Account account { get; set; } = default!;
}

