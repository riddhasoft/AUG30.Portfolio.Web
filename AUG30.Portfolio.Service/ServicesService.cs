using AUG30.Portfolio.Model;

namespace AUG30.Portfolio.Service
{
    public class ServicesService : IServicesService
    {
        private readonly MyDbContext _context;

        public ServicesService(MyDbContext context)
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

        public ServiceModel Detail(int id)
        {
            return _context.ServiceModel.Find(id);
        }

        public List<ServiceModel> Get()
        {
            return _context.ServiceModel.ToList();
        }

        public ServiceModel Save(ServiceModel model)
        {
            _context.ServiceModel.Add(model);
            _context.SaveChanges();
            return model;
        }

        public ServiceModel Update(ServiceModel model)
        {
            _context.ServiceModel.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
