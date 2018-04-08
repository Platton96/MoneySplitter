namespace MoneySplitter.Models.Session
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int CreditCardNumber { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
    }
}
