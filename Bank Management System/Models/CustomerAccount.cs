using Bank_Management_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models;

    public class CustomerAccount
    {
        public int accountId { get; set; }
        public Account account { get; set; }

        public int customerId { get; set; }
        public Customer customer { get; set; }
        public DateTime OwnerShipDate { get; set; }
        public OwnershipType ownershipType { get; set; }
        
        public AccountStatus accountStatus { get; set; }
    }

