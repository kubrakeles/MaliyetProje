using BelediyeCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeCore.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        //public DateTime? CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public DateTime? UpdateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string? CreatedEmail { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string? UpdatedEmail { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
