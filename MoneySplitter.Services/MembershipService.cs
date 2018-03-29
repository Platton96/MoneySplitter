using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MoneySplitter.Models;
using MoneySplitter.Models.Session;
using MoneySplitter.Services.API;
namespace MoneySplitter.Services
{
    public class MembershipService
    {
        private readonly SessionApiServices _sessionApiServices;

        public MembershipService()
        {
            _sessionApiServices = new SessionApiServices();
        }

        public async Task<UserModel> LoadUserData(LoginModel loginModel)
        {
            var user = await _sessionApiServices.SignIn(loginModel);

            return user;
        }
    }
}
