using Bank_Management_System.Contracts;
using Bank_Management_System.Extentions;
using Bank_Management_System.Models;
using Bank_Management_System.UI;
using ConsoleHelperV2;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Services;

    public class CustomerService(AppDbContext db) : ICustomer
    {
     
    public (bool success, string msg) AddCustomer(Customer customer)
    {
        if (customer is null)
            return (false, "InValid Customer Data");
        if (db.customers.Any(c => c.NationalID == customer.NationalID))
            return (false, "National Id is already located for a customer.");

            db.customers.Add(customer);
            db.SaveChanges();
        return (true, $"Customer created successfully, CustomerId = {customer.Id}");
        
    }

    public Customer GetCusotmerById(int id)
    {
        var customer = db.customers.FirstOrDefault(c => c.Id == id);
        return customer!;
    }

    public (bool success, string msg, IEnumerable<Customer> customers) ListAllCustomer()
    {
        var customers = db.customers
            .Include(c => c.accounts)
            .ThenInclude(ca => ca.account)
            .ThenInclude(a=>a.branch)
            .ToList();

        if (customers.Any())
        {
            return (true, "Returning all Customer with their accounts", customers);
        }
        return (false, "Error: Could not retrieve Data", default!);
    }
}

