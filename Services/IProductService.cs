using DataBaseManegmentSystem.Dto;
using DataBaseManegmentSystem.Models;

namespace DataBaseManegmentSystem.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProductsandCustomerAsync();

        public Task<IEnumerable<CustomerAndProduct>> GetProductsAsync();

        public Task<Product> GetProductsAsyncById(int id);

        public Task<Product> AddProduct(Product product);

        public Product DeleteProduct(Product product);


        public Product UpdateProduct(Product product);

        
    }
}
