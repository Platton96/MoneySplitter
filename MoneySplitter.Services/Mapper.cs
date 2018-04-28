using MoneySplitter.Models;
using MoneySplitter.Services.DataModels;
using MoneySplitter.Services.Inerfaces;
using MoneySplitter.Models.Session;

namespace MoneySplitter.Services
{
    public class Mapper : IMapper
    {
        public UserModel ConvertUserDataToUserModel(UserData userData)
        {
            if (userData==null)
            {
                return null;
            }

            var userModel = new UserModel()
            {
                Id = userData.Id,
                Name = userData.Name,
                Surname = userData.Surname,
                Email = userData.Email,
                PhoneNumber = userData.PhoneNumber,
                CreditCardNumber = userData.CreditCardNumber,
                Ballance = userData.Ballance,
                Token=userData.Token,
                ImageUrl=userData.ImageUrl
            };

            return userModel;
        }

        public RegisterUserData ConvertRegisterModelToRegisterUserData( RegisterModel registerModel)
        {
            var dataRegisterUser = new RegisterUserData()
            {
                Name = registerModel.Name,
                Surname = registerModel.Surname,
                Email = registerModel.Email,
                Password = registerModel.Password,
                PhoneNumber = registerModel.PhoneNumber,
                CreditCardNumber = registerModel.CreditCardNumber,
                ImageBase64String = registerModel.ImageBase64String,
                BackgroundImageBase64String=registerModel.BackgroundImageBase64String
            };

            return dataRegisterUser;
        }

    }
}
