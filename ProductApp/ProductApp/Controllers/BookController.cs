using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApp.Model;
using ProductApp.Repositories;

namespace ProductApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public BookController(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {

            try
            {
            var books = await _context.Products.ToListAsync();
            return Ok(books);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }


        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DelteOneProduct(int id)
        {
            try
            {
                var entity = await _context.Products.FindAsync(id);
                if(entity == null)
                    return NotFound();
                _context.Products.Remove(entity);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
