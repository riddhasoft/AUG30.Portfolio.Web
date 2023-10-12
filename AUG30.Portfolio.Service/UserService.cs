using AUG30.Portfolio.Model;

namespace AUG30.Portfolio.Service
{
    public class UserService : IUserService
    {
        private readonly MyDbContext _context;

        public UserService(MyDbContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            _context.UserModel.Remove(Detail(id));
            int result = _context.SaveChanges();
            if (result > 0)
            {
                return true;

            }
            return false;

        }

        public UserModel Detail(int id)
        {
            return _context.UserModel.Find(id);
        }

        public List<UserModel> Get()
        {
            return _context.UserModel.ToList();
        }

        public UserModel Save(UserModel model)
        {
            _context.UserModel.Add(model);
            _context.SaveChanges();
            return model;
        }

        public UserModel Update(UserModel model)
        {
            _context.UserModel.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
