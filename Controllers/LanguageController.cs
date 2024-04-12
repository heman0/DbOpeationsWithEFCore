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
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLanguageByIdAsync(int id)
        {
            var result = await context.tbl_Languages.FindAsync(id);
            return Ok(result);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetLanguageByNameAndDescriptionAsync(string name,[FromQuery] string? description)
        {
            // Get one record using Multiple(optional/required) Parameters or Paths
            var result = await context.tbl_Languages.
                FirstOrDefaultAsync
                (x => x.Title == name&&(string.IsNullOrEmpty(description)|| x.Description==description));
            return Ok(result);
        }
    }
}
