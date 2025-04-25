using LibrarySystem.Dtos;

namespace LibrarySystem.Services
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(int id);
        Task<BookDto> AddAsync(BookDto bookDto);
        Task<bool> UpdateAsync(int id, BookDto bookDto);
        Task<bool> DeleteAsync(int id);
    }
}
