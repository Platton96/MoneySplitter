namespace MoneySplitter.Models.Session
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public long CreditCardNumber { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string ImageBase64String { get; set; }
        public string BackgroundImageBase64String { get; set; }
    }
}
