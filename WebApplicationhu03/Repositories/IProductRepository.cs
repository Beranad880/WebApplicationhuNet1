using WebApplicationhu03.Models;

namespace WebApplicationhu03.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        void Update(Product product);
        void Delete(int id);
        Task SaveAsync();
    }
}

