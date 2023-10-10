using AUG30.Portfolio.Web.Models;

namespace AUG30.Portfolio.Web
{
    public interface IProfileService
    {
        List<ProfileModel> Get();
        ProfileModel Save(ProfileModel model);
        ProfileModel Update(ProfileModel model);
        bool Delete(int id);
        ProfileModel Detail(int id);
    }
}
