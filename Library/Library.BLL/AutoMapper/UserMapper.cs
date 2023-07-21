using AutoMapper;
using Library.BLL.DTO;
using Library.BLL.Interface;
using Library.DAL.Modell;

namespace Library.BLL.AutoMapper
{
    public class UserMapper:IUserMapper
    {
        private readonly IMapper _mapper;

        public UserMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserDTO MapToDTO(User user)
        {
            return _mapper.Map<UserDTO>(user);
        }

        public User MapToEntity(UserDTO newUserDto)
        {
            return _mapper.Map<User>(newUserDto);
        }
    }
}
