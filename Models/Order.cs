namespace DataBaseManegmentSystem.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; }

        public DateTime DateTime { get; set; }



        public List<OrderItem> OrderItems { get; set; }

    }
}
