namespace GestaoLivraria
{
    public class BookGenre
    {
        public const string Fiction = "Ficção";
        public const string Science = "Ciência";
        public const string History = "História";
        public const string Fantasy = "Fantasia";
        public const string Mystery = "Mistério";
        public const string Romance = "Romance";

        public static readonly string[] AllGenres = new[]
        {
            Fiction, Science, History, Fantasy, Mystery, Romance
        };

        public static bool IsInvalid(string valor)
        {
            return !AllGenres.Contains(valor, StringComparer.OrdinalIgnoreCase);
        }
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
