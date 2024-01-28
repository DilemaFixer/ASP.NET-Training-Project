namespace UdemProject.Data.IRepository.Product
{

    public class ProductRepository : Repository<Data.Product>, IProductRepository
    {
        private readonly ApplicationDbContext _repository;
        public ProductRepository(ApplicationDbContext context) : base(context) => _repository = context;

        public void Save()
        {
            _repository.SaveChanges();
        }

        public void Update(Data.Product product)
        {
            _repository.Update(product);
        }
    }
}
