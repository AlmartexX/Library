using AutoMapper;
using Library.BLL.DTO;
using Library.DAL.Modell;

namespace Library.BLL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
            CreateMap<CreateBookDTO, Book>();
            CreateMap<UpdateBookDTO, Book>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

        }
    }
}
