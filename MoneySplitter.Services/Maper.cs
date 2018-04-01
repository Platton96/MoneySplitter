using MoneySplitter.Infrastructure;
using MoneySplitter.Models;

namespace MoneySplitter.Services
{
    public class Maper : IMaper
    {
        public UserModel ToConvertUserModel<TDataUser> ( TDataUser dataUser)
            where TDataUser:IUserModel
        {
            var userModel = new UserModel()
            {
                Id = dataUser.Id,
                Name = dataUser.Name,
                Surname = dataUser.Surname,
                Email = dataUser.Email,
                PhoneNumber = dataUser.PhoneNumber,
                CreditCardNumber = dataUser.CreditCardNumber,
                Ballance = dataUser.Ballance
            };
            return userModel;
        }

      
    }
}
