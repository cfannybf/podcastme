using backend.Objects;

namespace backend.Repositories
{
    public interface IProfileRepostory
    {
        Profile Get(string id);
    }
}