using DSW1_T2_SermenoCruzMarcos.Application.DTOs.Book;

namespace DSW1_T2_SermenoCruzMarcos.Application.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> CreateBookAsync(CreateBookDto dto);
        Task<BookDto?> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task UpdateBookAsync(UpdateBookDto dto);
        Task DeleteBookAsync(int id);
    }
}