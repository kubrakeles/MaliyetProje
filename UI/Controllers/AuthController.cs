using MaliyetBusiness.Abstract;
using MaliyetEntities.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UI.Models;

namespace UI.Controllers
{
        public class AuthController : Controller
    {
        
        IAuthService _authService;
       
        public AuthController(IAuthService authService)
        {
                _authService = authService;
        }
     
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            
            try 
            {
                if (ModelState.IsValid)
                { 
                var userToLogin = _authService.Login(userForLoginDto);
                if (!userToLogin.Success) //işlem sonucu başarılı değilse
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı Bulunamadı veya Bilgileri Yanlış Girildi!");
                    return this.RedirectToPage("/Auth/Login");
                }
                var result = _authService.CreateAccessToken(userToLogin.Data);
                 if(result.Success)
                 {


                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, userForLoginDto.Email),
                        
                        };
                        var claimsIdentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties();

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal
                            (claimsIdentity), authProperties);
                        return RedirectToAction("index", "Tender");
                 }
                }
            }
            catch (Exception Ex) 
            {
                Console.WriteLine(Ex);
            }
            return this.RedirectToPage("/Tender/Index");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserForRegisterDto userForRegisterDto) 
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var RegisterResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(RegisterResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        public async Task<IActionResult> OnPostLogOff()
        {
            try
            {
                // Setting.
                var authenticationManager = Request.HttpContext;

                // Sign Out.
                await authenticationManager.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }

            // Info.
            return this.RedirectToAction("Login", "Auth");
        }
    }
}
