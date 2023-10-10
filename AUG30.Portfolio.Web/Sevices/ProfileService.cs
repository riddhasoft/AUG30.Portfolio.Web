using AUG30.Portfolio.Web.Models;

namespace AUG30.Portfolio.Web
{
    public class ProfileService : IProfileService
    {
        private readonly MyDbContext _context;

        public ProfileService(MyDbContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            _context.Remove(id);
            int result = _context.SaveChanges();
            if (result > 0)
            {
                return true;

            }
            return false;

        }

        public ProfileModel Detail(int id)
        {
            return _context.ProfileModel.Find(id);
        }

        public List<ProfileModel> Get()
        {
            return _context.ProfileModel.ToList();
        }

        public ProfileModel Save(ProfileModel model)
        {
            _context.ProfileModel.Add(model);
            _context.SaveChanges();
            return model;
        }

        public ProfileModel Update(ProfileModel model)
        {
            _context.ProfileModel.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
