using Library.BLL.DTO;

namespace Library.BLL.Interface
{
    public interface IUserService
    {
        Task<UserDTO> Register(UserDTO userDTO);
        Task<bool> Authenticate(string name, string password);
    }
}
