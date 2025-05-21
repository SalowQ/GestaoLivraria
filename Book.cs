namespace GestaoLivraria
{
    public enum BookGenre
    {
        Fiction,
        NonFiction,
        Science,
        History,
        Fantasy,
        Mystery,
        Romance,
        Thriller,
        Horror,
        Biography
    }
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public BookGenre Genre { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
