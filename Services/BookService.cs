using AutoMapper;
using LibrarySystem.Dtos;
using LibrarySystem.Models;
using LibrarySystem.Repositories;

namespace LibrarySystem.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();
            return _mapper.Map<List<BookDto>>(books);
        }

        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            return book == null ? null : _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> AddAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var added = await _repository.AddAsync(book);
            return _mapper.Map<BookDto>(added);
        }

        public async Task<bool> UpdateAsync(int id, BookDto bookDto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(bookDto, existing); // atualiza os campos
            await _repository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return false;

            await _repository.DeleteAsync(book);
            return true;
        }
    }
}
