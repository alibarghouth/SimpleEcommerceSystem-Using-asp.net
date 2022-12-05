using DataBaseManegmentSystem.Models;

namespace DataBaseManegmentSystem.Dto
{
    public class CustomerJson<T>
    {
        public T Customer { get; set; }

        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }

        public CustomerJson() { }

        public CustomerJson(T customer)
        {
            Customer = customer;
            Succeeded= true;
            Errors = new string[0];
            Message = string.Empty;
        }
    }
}
