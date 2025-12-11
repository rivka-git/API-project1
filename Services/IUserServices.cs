using Model;

namespace Services
{
    public interface IUserServices
    {
        Task<User> AddNewUser(User user);
        void Delete(int id);
        Task<User?> GetUserById(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<User?> Login(User value);
        Task<User> update(int id, User value);
    }
}
