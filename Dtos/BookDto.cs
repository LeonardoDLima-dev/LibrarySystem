namespace LibrarySystem.Dtos
{
    public class BookDto
    {
        public int Id { get; set; } // pode ser omitido no POST, mas útil no PUT e GET
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Category { get; set; }
        public int Year { get; set; }
    }
}
