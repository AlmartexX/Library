using Library.DAL.Modell;

namespace Library.DAL.Interface
{
    public interface IUserRepository
    {
        Task RegisterUser(User user);

        Task<User> GetUserByName(string userName);


    }
}
