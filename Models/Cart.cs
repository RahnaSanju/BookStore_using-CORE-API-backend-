namespace BookStoreAPI.Models
{
    public class Cart:Book
    {
        public int Cart_Id { get; set; }
        public int User_Id { get; set; }
        public int Qty { get; set; }

    }
}
