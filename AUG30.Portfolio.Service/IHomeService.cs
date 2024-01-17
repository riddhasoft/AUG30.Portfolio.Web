using AUG30.Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUG30.Portfolio.Service
{
    public interface IHomeService
    {
        public List<CLientModel> GetCLients();
    }
    public class HomeService : IHomeService
    {
        private readonly MyDbContext _context;

        public HomeService(MyDbContext context)
        {
            _context = context;
        }
        public List<CLientModel> GetCLients()
        {
            return _context.ClientModel.ToList();
        }
    }
}
