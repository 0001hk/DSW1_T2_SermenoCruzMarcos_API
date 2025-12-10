using DSW1_T2_SermenoCruzMarcos.Application.DTOs;
using System.Threading.Tasks; 
using System.Collections.Generic; 
using DSW1_T2_SermenoCruzMarcos.Application.DTOs.Loan; // ¡Para TODOS los demás DTOs!

namespace DSW1_T2_SermenoCruzMarcos.Application.Services.Interfaces
{
    public interface ILoanService
    {
        Task<LoanDto> CreateLoanAsync(CreateLoanDto dto);
        Task<LoanDto?> GetLoanByIdAsync(int id);
        Task<IEnumerable<LoanDto>> GetActiveLoansAsync();
        Task ReturnLoanAsync(int id); 
    }
}