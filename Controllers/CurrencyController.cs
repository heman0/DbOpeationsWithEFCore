using DbOpeationsWithEFCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOpeationsWithEFCore.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext context;

        public CurrencyController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            // var result= this.context.tbl_Currencies.ToList();
            var result = await (from currencies in context.tbl_Currencies
                               select currencies).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrencyByIdAsync(int id)
        {
            var result = await context.tbl_Currencies.FindAsync(id);
            return Ok(result);
        }
    }
}
