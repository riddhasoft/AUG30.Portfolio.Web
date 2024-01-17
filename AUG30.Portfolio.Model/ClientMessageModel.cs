using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUG30.Portfolio.Model
{
    public class ClientMessageModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int ClientId { get; set; }

        public virtual CLientModel CLient { get; set; }
    }
}
