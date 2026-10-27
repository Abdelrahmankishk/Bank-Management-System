using Bank_Management_System.Extentions;
using Bank_Management_System.Models;
using Bank_Management_System.UI;
using ConsoleHelperV2;
namespace Bank_Management_System.Services;

    public class CustomerService(AppDbContext db)
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


}

