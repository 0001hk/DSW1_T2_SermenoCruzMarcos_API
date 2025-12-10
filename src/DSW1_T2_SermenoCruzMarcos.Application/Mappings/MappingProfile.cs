using AutoMapper;
using DSW1_T2_SermenoCruzMarcos.Domain.Entities;
using DSW1_T2_SermenoCruzMarcos.Application.DTOs.Loan; 
using DSW1_T2_SermenoCruzMarcos.Application.DTOs.Book;

namespace DSW1_T2_SermenoCruzMarcos.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            
            CreateMap<Loan, LoanDto>()
                .ForMember(dest => dest.BookTitle, 
                           opt => opt.MapFrom(src => src.Book != null ? src.Book.Title : "N/A"));

            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
            CreateMap<CreateLoanDto, Loan>();
        }
    }
}