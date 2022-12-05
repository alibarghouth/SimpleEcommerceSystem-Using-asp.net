using Add_Database_Model.Models;
using DataBaseManegmentSystem.Dto;
using DataBaseManegmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseManegmentSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDBContext _Context;

        public CustomerService(ApplicationDBContext context)
        {
            _Context = context;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var customers = await _Context.Customers.AddAsync(customer);

            _Context.SaveChanges();

            return customer;
        }

        public  Customer DeleteCustomer(Customer customer)
        {
            _Context.Customers.Remove(customer);
            _Context.SaveChanges();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _Context.Customers
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _Context.Customers.FindAsync(id);
        }

        public async Task<Customer> GetCustomerByName(string name)
        {
            return await _Context.Customers.SingleOrDefaultAsync(cc => cc.LastName == name);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _Context.Update(customer);

            _Context.SaveChanges();

            return(customer);
        }
    }
}
