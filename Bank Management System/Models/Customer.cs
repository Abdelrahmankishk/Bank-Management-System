using Bank_Management_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models;

    public class Customer
    {
    public int Id { get; set; }
    public string FullName { get; set; } = default!;
    public string? Address { get; set; }
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string NationalID { get; set; } = default!;
    public CustomerType Type { get; set; }
    public DateOnly DateOfBirth { get; set; }
}

