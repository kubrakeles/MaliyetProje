using MaliyetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetCore.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        //public DateTime? CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public DateTime? UpdateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string? CreatedEmail { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string? UpdatedEmail { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
