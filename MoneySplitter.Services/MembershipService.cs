using System.Threading.Tasks;
using MoneySplitter.Models;
using MoneySplitter.Services.Api;
using MoneySplitter.Infrastructure;
using MoneySplitter.Services.DataModels;

namespace MoneySplitter.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly ISessionApiService<DataUser> _sessionApiServices;

        public UserModel CurrentUser { get; private set; }

        public MembershipService(ISessionApiService<DataUser> sessionApiService)
        {
            _sessionApiServices = sessionApiService;
        }

        public async Task LoadUserData(string email, string password)
        {
            var dataUser = await _sessionApiServices.SignInAsync(email, password);

            CurrentUser = new UserModel
            {
                Id = dataUser.Id,
                Name = dataUser.Name,
                Surname = dataUser.Surname,
                Email = dataUser.Email,
                PhoneNumber = dataUser.PhoneNumber,
                CreditCardNumber = dataUser.CreditCardNumber,
                Ballance = dataUser.Ballance
            };

        }
    }
}
