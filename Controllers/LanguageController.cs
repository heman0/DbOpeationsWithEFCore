using DbOpeationsWithEFCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOpeationsWithEFCore.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext context;

        public LanguageController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllLanguages()
        {
            var result = await (from lanugages in context.tbl_Languages
                         select lanugages).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguageByIdAsync(int id)
        {
            var result = await context.tbl_Languages.FindAsync(id);
            return Ok(result);
        }
    }
}
