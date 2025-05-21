namespace GestaoLivraria
{
    public class BookGenre
    {
        public const string Fiction = "Fiction";
        public const string NonFiction = "Non-Fiction";
        public const string Science = "Science";
        public const string History = "History";
        public const string Fantasy = "Fantasy";
        public const string Mystery = "Mystery";
        public const string Romance = "Romance";
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
