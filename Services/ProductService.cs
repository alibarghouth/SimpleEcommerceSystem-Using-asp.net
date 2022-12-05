using Add_Database_Model.Models;
using DataBaseManegmentSystem.Dto;
using DataBaseManegmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseManegmentSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDBContext _context;

        public ProductService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            _context.SaveChanges();
            return product;
        }

        public Product DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }

        public async Task<IEnumerable<CustomerAndProduct>> GetProductsAsync()
        {
            return await _context.Products
                .Select(x => new CustomerAndProduct
                {
                    Name = x.Name,
                    ProductImage = x.ProductImage,
                    ProductLocation = x.ProductLocation,
                    CustomerId = x.CustomerId,
                    OrderId = x.OrderId,
                    Id = x.Customer.Id,
                    FirstName = x.Customer.FirstName,
                    LastName = x.Customer.LastName,
                    ProductId = x.Id,
                    CardId = x.Customer.CardId

                })
              .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsandCustomerAsync()
        {
            return await _context.Products
                .Include(x => x.Customer)
                
                .ToListAsync();
        }

        public async Task<Product> GetProductsAsyncById(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(x=> x.Id == id);
        }

        public Product UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
        }

        
    }
}
