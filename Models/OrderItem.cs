namespace DataBaseManegmentSystem.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public byte[] OrderItemImage { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
