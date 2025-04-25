// Models/Book.cs
namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; } // Chave primária
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
