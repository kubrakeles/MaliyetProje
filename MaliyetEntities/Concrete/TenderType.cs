using MaliyetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetEntities.Concrete
{
    public class TenderType: IEntity
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public ICollection<Tender> Tenders { get; set; }

    }
}
