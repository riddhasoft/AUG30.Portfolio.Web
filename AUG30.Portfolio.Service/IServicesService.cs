using AUG30.Portfolio.Model;

namespace AUG30.Portfolio.Service
{
    public interface IServicesService
    {
        List<ServiceModel> Get();
        ServiceModel Save(ServiceModel model);
        ServiceModel Update(ServiceModel model);
        bool Delete(int id);
        ServiceModel Detail(int id);


    }
}
