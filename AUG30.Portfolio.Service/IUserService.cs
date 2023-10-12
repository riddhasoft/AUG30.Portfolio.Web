using AUG30.Portfolio.Model;

namespace AUG30.Portfolio.Service
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
