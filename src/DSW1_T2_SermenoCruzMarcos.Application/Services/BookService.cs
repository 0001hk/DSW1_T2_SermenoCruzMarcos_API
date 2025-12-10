using DSW1_T2_SermenoCruzMarcos.Application.DTOs;
using DSW1_T2_SermenoCruzMarcos.Application.DTOs.Book;
using DSW1_T2_SermenoCruzMarcos.Application.DTOs.Loan;
using DSW1_T2_SermenoCruzMarcos.Application.Services.Interfaces;
using DSW1_T2_SermenoCruzMarcos.Domain.Entities;
using DSW1_T2_SermenoCruzMarcos.Domain.Ports.Out;
using AutoMapper;

namespace DSW1_T2_SermenoCruzMarcos.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _unitOfWork.Books.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            book.CreatedAt = DateTime.Now;
            
            await _unitOfWork.Books.AddAsync(book);
            
            try 
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                 if (ex.InnerException?.Message.Contains("unique index") == true)
                 {
                     throw new Exception("El ISBN ingresado ya existe en la base de datos.");
                 }
                 throw; 
            }
            return _mapper.Map<BookDto>(book);
        }

        public async Task UpdateBookAsync(UpdateBookDto dto)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(dto.Id);

            if (book == null)
                throw new Exception($"Libro con ID {dto.Id} no encontrado."); 

            _mapper.Map(dto, book); 
            
            await _unitOfWork.Books.UpdateAsync(book);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(id);

            if (book == null)
                throw new Exception($"Libro con ID {id} no encontrado para eliminar.");
                
            await _unitOfWork.Books.DeleteAsync(book.Id); 
            await _unitOfWork.SaveChangesAsync();
        }
    }
}