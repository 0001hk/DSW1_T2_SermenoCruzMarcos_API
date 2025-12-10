using Microsoft.AspNetCore.Mvc;
using DSW1_T2_SermenoCruzMarcos.Application.Services.Interfaces;
using DSW1_T2_SermenoCruzMarcos.Application.DTOs;
using System.Net;
using DSW1_T2_SermenoCruzMarcos.Application.DTOs.Book; 
using DSW1_T2_SermenoCruzMarcos.Application.DTOs.Loan;

[Route("api/[controller]")]
[ApiController]
public class LoanController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoanController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<LoanDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetActiveLoans()
    {
        var loans = await _loanService.GetActiveLoansAsync();
        return Ok(loans);
    }

    [HttpPost]
    [ProducesResponseType(typeof(LoanDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateLoanDto dto)
    {
        try
        {
            var loan = await _loanService.CreateLoanAsync(dto);
            return CreatedAtAction(nameof(GetActiveLoans), loan);
        }
        catch (Exception ex) 
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPut("return/{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Return(int id)
    {
        try
        {
            await _loanService.ReturnLoanAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}