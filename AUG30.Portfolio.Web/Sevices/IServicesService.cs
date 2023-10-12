using AUG30.Portfolio.Web.Models;

namespace AUG30.Portfolio.Web.Sevices
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
