using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models;

    public class Branch
    {
    public int Code { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public Manager manager { get; set; } = default!;

    public ICollection<Account> accounts { get; set; } = new List<Account>();
}

