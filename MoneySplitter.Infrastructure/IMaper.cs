using MoneySplitter.Models;


namespace MoneySplitter.Infrastructure
{
    public interface IMaper
    {
        UserModel ToConvertUserModel<TDataUser> (TDataUser paramtaetr) where TDataUser : IUserModel;
    }
}
