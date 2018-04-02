using MoneySplitter.Models;


namespace MoneySplitter.Infrastructure
{
    public interface IMapper
    {
        UserModel ToConvertUserModel<TDataUser> (TDataUser paramtaetr) where TDataUser : IUserModel;
    }
}
