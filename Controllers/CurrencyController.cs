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
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrencyByIdAsync(int id)
        {
            var result = await context.tbl_Currencies.FindAsync(id);
            return Ok(result);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencyByNameAsync(string name)
        {
            //1.)------Does not return any exception or error if no record found
             var result = await context.tbl_Currencies.FirstOrDefaultAsync(x => x.Title == name); 

            //2.)------Returns an exception if no record is found
            // var result = await context.tbl_Currencies.Where(x => x.Title == name).FirstAsync();

            //3.)-----Same as FirstAsync or also returns an exception if duplicate records are found
            //var result = await context.tbl_Currencies.Where(x => x.Title == name).SingleAsync();

            //4.)-----In case of SingleOrDefault it throws an exception if duplicate records are exist in database
            //var result = await context.tbl_Currencies.Where(x => x.Title == name).SingleOrDefaultAsync();



            return Ok(result);
        }
    } 
}
