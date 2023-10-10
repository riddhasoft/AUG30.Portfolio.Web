using AUG30.Portfolio.Web.Models;

namespace AUG30.Portfolio.Web
{
    public interface IUserService
    {
        List<UserModel> Get();
        UserModel Save(UserModel model);
        UserModel Update(UserModel model);
        bool Delete(int id);
        UserModel Detail(int id);
    }
}
