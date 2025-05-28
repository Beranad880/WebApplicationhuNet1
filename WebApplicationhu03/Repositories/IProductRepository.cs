using WebApplicationhu03.Controllers;

namespace WebApplicationhu03.Repositories
{
    public interface IProductRepository{
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        void Save();
    }
}

