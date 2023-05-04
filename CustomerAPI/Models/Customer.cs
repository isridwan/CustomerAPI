namespace CustomerAPI.Models
{
    public class Customer
    {
        public int customerId { get; set; }
        public string customerName { get; set; } = string.Empty;
        public string customerAddress { get; set; } = string.Empty;
        public string customerPhoneNumber { get; set; } = string.Empty;
    }
}
