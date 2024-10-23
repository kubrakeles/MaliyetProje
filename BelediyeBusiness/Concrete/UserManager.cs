using BelediyeBusiness.Abstract;
using BelediyeCore.Entities.Concrete;
using BelediyeDataAccess.Abstract;
using BelediyeEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeBusiness.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDAL _userDal;
        public UserManager(IUserDAL userDAL)
        {
            _userDal= userDAL;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByEmail(string email)
        {
            return _userDal.Get(filter: u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
