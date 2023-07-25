
using Library.BLL.DTO;
using Library.DAL.Modell;

namespace Library.BLL.Interface
{
    public interface IUserMapper
    {
        UserDTO MapToDTO(User book);
        User MapToEntity(UserDTO newBookDto);
    }
}
