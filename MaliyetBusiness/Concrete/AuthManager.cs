using MaliyetBusiness.Abstract;
using MaliyetCore.Entities.Concrete;
using MaliyetCore.Utilities.Messages;
using MaliyetCore.Utilities.Results;
using MaliyetCore.Utilities.Security.Encryption.Hashing;
using MaliyetCore.Utilities.Security.Jwt;
using MaliyetEntities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetBusiness.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken);

        }


        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            //Kullanıcıyı bulduk şimdi kullanıcının gönderdiği şifreyi kontrol edicez.
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            //buraya gelirse veriler doğru demek 
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto,string password)
        {
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);//Bu metod ile password hash ve password salt üretiliyor
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true//Bunu mail aldıktan sonra doğrulayarak true yapabiliriz.
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }


        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email) != null)
            {//kullanıcı kayıt olmaya çalıştığında böyle bir e-mail varsa böyle bir hata döndürüyoruz.
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }


    }
}
