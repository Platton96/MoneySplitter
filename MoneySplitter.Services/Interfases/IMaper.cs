using MoneySplitter.Models;
using MoneySplitter.Models.Session;
using MoneySplitter.Services.DataModels;

namespace MoneySplitter.Services.Inerfaces
{
    public interface IMapper
    {
        UserModel ConvertDataUserToUserModel(DataUser dataUser);
        DataRegisterUser ConvertRegisterModelToDataRegisterUser(RegisterModel registerModel);
        DataGetUser ConvertUserModelToDataGetUser(UserModel userModel);
    }
}
