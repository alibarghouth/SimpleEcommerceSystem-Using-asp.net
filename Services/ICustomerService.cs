using DataBaseManegmentSystem.Models;

namespace DataBaseManegmentSystem.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Object>> searchProduct(string name);


        Task<IEnumerable<Customer>> GetAllCustomer();

        Task<Customer> GetCustomerById(int id);

        Task<Customer> GetCustomerByName(string name);

        Task<Customer> AddCustomer(Customer customer);

        Customer DeleteCustomer(Customer customer);


        Customer UpdateCustomer(Customer customer);
    }
}
