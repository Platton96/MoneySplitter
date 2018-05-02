using MoneySplitter.Models;
using MoneySplitter.Services.DataModels;
using MoneySplitter.Services.Inerfaces;
using MoneySplitter.Models.Session;

namespace MoneySplitter.Services
{
    public class Mapper : IMapper
    {
        public UserModel ConvertDataUserToUserModel(UserData dataUser)
        {
            if (dataUser==null)
            {
                return null;
            }

            var userModel = new UserModel()
            {
                Id = dataUser.Id,
                Name = dataUser.Name,
                Surname = dataUser.Surname,
                Email = dataUser.Email,
                PhoneNumber = dataUser.PhoneNumber,
                CreditCardNumber = dataUser.CreditCardNumber,
                Ballance = dataUser.Ballance,
                Token=dataUser.Token,
                ImageUrl=dataUser.ImageUrl
            };

            return userModel;
        }

        public RegisterUserData ConvertRegisterModelToDataRegisterUser( RegisterModel registerModel)
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
