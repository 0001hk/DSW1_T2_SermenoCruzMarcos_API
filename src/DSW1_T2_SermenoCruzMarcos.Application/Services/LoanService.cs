using DSW1_T2_SermenoCruzMarcos.Application.DTOs.Loan;
using DSW1_T2_SermenoCruzMarcos.Application.DTOs;
using DSW1_T2_SermenoCruzMarcos.Domain.Entities;
using DSW1_T2_SermenoCruzMarcos.Domain.Ports.Out;
using AutoMapper;
using System.Threading.Tasks; 
using System.Collections.Generic; 
using DSW1_T2_SermenoCruzMarcos.Application.Services.Interfaces;

namespace DSW1_T2_SermenoCruzMarcos.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoanService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LoanDto>> GetActiveLoansAsync()
        {
            var allLoans = await _unitOfWork.Loans.GetAllAsync();
            var activeLoans = allLoans.Where(l => l.Status == "Active"); 
            
            return _mapper.Map<IEnumerable<LoanDto>>(activeLoans);
        }
        
        public async Task<LoanDto?> GetLoanByIdAsync(int id)
        {
            var loan = await _unitOfWork.Loans.GetByIdAsync(id);
            return _mapper.Map<LoanDto>(loan);
        }

        public async Task<LoanDto> CreateLoanAsync(CreateLoanDto dto)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(dto.BookId);

            if (book == null)
                throw new Exception("Libro no encontrado."); 

            if (book.Stock <= 0)
            {
                throw new Exception($"El libro '{book.Title}' no tiene stock disponible."); 
            }

            book.Stock--;
            await _unitOfWork.Books.UpdateAsync(book);

            var loan = _mapper.Map<Loan>(dto);
            loan.LoanDate = DateTime.Now;
            loan.Status = "Active";
            loan.CreatedAt = DateTime.Now;
            
            await _unitOfWork.Loans.AddAsync(loan);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<LoanDto>(loan);
        }

        public async Task ReturnLoanAsync(int id)
        {
            var loan = await _unitOfWork.Loans.GetByIdAsync(id);

            if (loan == null || loan.Status == "Returned")
                throw new Exception("Préstamo no válido o ya devuelto."); 
            
            var book = await _unitOfWork.Books.GetByIdAsync(loan.BookId);

            if (book == null)
                throw new Exception("Libro asociado al préstamo no encontrado."); 

            // Regla de Negocio: Aumentar el stock del libro
            book.Stock++;
            await _unitOfWork.Books.UpdateAsync(book);

            // Marcar el préstamo como devuelto
            loan.Status = "Returned";
            loan.ReturnDate = DateTime.Now;
            await _unitOfWork.Loans.UpdateAsync(loan);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}