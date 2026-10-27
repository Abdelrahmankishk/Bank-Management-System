using Bank_Management_System.Contracts;
using Bank_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Services
{
    public class BranchService(AppDbContext dbContext) : IBranch
    {
        public Branch GetBracnhByCode(int Code)
        {
            var branch = dbContext.branches.FirstOrDefault(b=>b.Code == Code);
            return branch!;
        }
    }
}
