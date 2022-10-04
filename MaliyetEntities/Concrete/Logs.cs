using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetEntities.Concrete
{
    public class Logs
    {
        public int id { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string Audit { get; set; }
    }
}
