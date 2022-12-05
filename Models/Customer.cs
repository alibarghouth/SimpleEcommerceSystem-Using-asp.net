namespace DataBaseManegmentSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CardId { get; set; }

        public List<Product> Products { get; set; }
    }
}
