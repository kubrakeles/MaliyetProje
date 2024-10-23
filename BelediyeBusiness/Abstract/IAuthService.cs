using BelediyeCore.Entities.Concrete;
using BelediyeCore.Utilities.Results;
using BelediyeCore.Utilities.Security.Jwt;
using BelediyeEntities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeBusiness.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto,string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult UserExists(string email);

    }
}
