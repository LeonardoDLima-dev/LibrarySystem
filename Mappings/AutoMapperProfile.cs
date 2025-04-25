using AutoMapper;
using LibrarySystem.Dtos;
using LibrarySystem.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibrarySystem.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap(); // mapeia entre Book e BookDto nos dois sentidos
        }
    }
}
