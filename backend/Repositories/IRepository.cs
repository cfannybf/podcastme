namespace backend.Repositories
{
    public interface IRepository<T>
    {
        T Get(string id);
    }
}