using MoneySplitter.Infrastructure;
using MoneySplitter.Models;
using MoneySplitter.Services.DataModels;
using MoneySplitter.Services.Inerfaces;
using MoneySplitter.Models.Session;

namespace MoneySplitter.Services
{
    public class Mapper : IMapper
    {
        public UserModel ConvertDataUserToUserModel(DataUser dataUser)
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

        public DataRegisterUser ConvertRegisterModelToDataRegisterUser( RegisterModel registerModel)
        {
            var dataRegisterUser = new DataRegisterUser()
            {
                Name = registerModel.Name,
                Surname = registerModel.Surname,
                Email = registerModel.Email,
                Password =registerModel.Password,
                PhoneNumber = registerModel.PhoneNumber,
                CreditCardNumber = registerModel.CreditCardNumber
            };

            return dataRegisterUser;
        }
    }
}
