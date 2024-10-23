using BelediyeCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeEntities.Concrete
{
    public class TenderType: IEntity
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public ICollection<Tender> Tenders { get; set; }
        public DateTime? CreatedDate { get ; set ; }
        public DateTime ?UpdateDate { get ; set ; }
        public string ?CreatedEmail { get ; set ; }
        public string ?UpdatedEmail { get ; set ; }
    }
}
