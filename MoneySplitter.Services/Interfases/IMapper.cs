using MoneySplitter.Models;
using MoneySplitter.Models.Session;
using MoneySplitter.Services.DataModels;

namespace MoneySplitter.Services.Inerfaces
{
    public interface IMapper
    {
        UserModel ConvertUserDataToUserModel(UserData userData);
        RegisterUserData ConvertRegisterModelToRegisterUserData(RegisterModel registerModel);
    }
}
