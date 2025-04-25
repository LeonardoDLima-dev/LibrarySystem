using LibrarySystem.Dtos;
using LibrarySystem.Services;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Data; // Adicione isso para usar o ApplicationDbContext
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace LibrarySystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly AppDbContext _context;

        public BooksController(IBookService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _service.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _service.GetByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }

        // 👇 Endpoint de Teste de Conexão com o Banco de Dados
        [HttpGet("test-connection")]
        public IActionResult TestConnection()
        {
            try
            {
                var canConnect = _context.Database.CanConnect();
                return canConnect
                    ? Ok("Conexão com o banco de dados estabelecida com sucesso.")
                    : StatusCode(500, "Não foi possível conectar ao banco de dados.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao testar a conexão: {ex.Message}");
            }
        }
    }
}
