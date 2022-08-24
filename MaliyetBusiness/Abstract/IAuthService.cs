﻿using MaliyetCore.Entities.Concrete;
using MaliyetCore.Utilities.Results;
using MaliyetCore.Utilities.Security.Jwt;
using MaliyetEntities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetBusiness.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto,string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult UserExists(string email);



    }
}
