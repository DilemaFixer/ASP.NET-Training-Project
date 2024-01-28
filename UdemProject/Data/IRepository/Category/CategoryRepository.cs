
namespace UdemProject.Data.IRepository.Category
{
    public class CategoryRepository : Repository<Data.Category>, ICategoryInterafce
    {
        private ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context) => _context = context;

        public void Save() => _context.SaveChanges();

        public void Update(Data.Category category) => _context.Update(category);
    }
}
