using AUG30.Portfolio.Model;

namespace AUG30.Portfolio.Service
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
