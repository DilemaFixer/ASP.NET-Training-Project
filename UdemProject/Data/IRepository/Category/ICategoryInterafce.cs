namespace UdemProject.Data.IRepository.Category
{
    public interface ICategoryInterafce : IRepository<Data.Category>
    {
        void Update(Data.Category category);
        void Save();
    }
}
