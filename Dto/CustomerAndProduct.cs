namespace DataBaseManegmentSystem.Dto
{
    public class CustomerAndProduct
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CardId { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public string ProductLocation { get; set; }

        public byte[] ProductImage { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }

    }
}
