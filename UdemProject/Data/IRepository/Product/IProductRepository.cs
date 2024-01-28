namespace UdemProject.Data.IRepository.Product
{
    public interface IProductRepository : IRepository<Data.Product>
    {
        void Save();
        void Update(Data.Product product);
    }
}
