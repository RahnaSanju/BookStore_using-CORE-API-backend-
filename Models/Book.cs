namespace BookStoreAPI.Models
{
    public class Book
    {
        public int Book_Id { get; set; }
        public string? Book_Name { get; set; }
        public string? Book_Author { get; set; }
        public double Book_Price { get; set; }

        public string? searchTitle { get; set; }
        public string? searchAuthor { get; set; }
        public double searchPrice { get; set; }
    }
}
