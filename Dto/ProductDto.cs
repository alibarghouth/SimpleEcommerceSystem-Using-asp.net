namespace DataBaseManegmentSystem.Dto
{
    public class ProductDto
    {
        public string Name { get; set; }

        public string ProductLocation { get; set; }

        public IFormFile ProductImage { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }


    }
}
