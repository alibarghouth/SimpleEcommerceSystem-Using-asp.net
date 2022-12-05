namespace DataBaseManegmentSystem.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ProductLocation { get; set; }

        public byte[] ProductImage { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }


        public Customer Customer { get; set; }

        public Order Order { get; set; }
    }
}
