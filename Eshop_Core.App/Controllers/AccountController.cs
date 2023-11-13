using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop_Core.App.Models;
using Eshop_Core.App.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Eshop_Core.App.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region Register

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.IsExistUserByEmail(register.Email.ToLower()))
                {
                    ModelState.AddModelError("Email", "ایمیل وارد شده تکراری می باشد");
                    return View(register);
                }
                else
                {
                    Users users = new Users()
                    {
                        Email = register.Email.ToLower(),
                        Password = register.Password,
                        IsAdmin = false,
                        RegisterDate = DateTime.Now
                    };

                    _userRepository.AddUser(users);

                    return View("SuccessRegister", register);
                }
            }
            return View(register);
        }

        public IActionResult VerifyEmail(string email)
        {
            if (_userRepository.IsExistUserByEmail(email.ToLower()))
            {
                return Json("ایمیل وارد شده تکراری می باشد");
            }

            return Json(true);
        }

        #endregion

        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.GetUserForLogin(login.Email.ToLower(), login.Password);
                if (user == null)
                {
                    ModelState.AddModelError("Email", "نام کاربری یا کلمه عبور اشتباه است");
                    return View(login);
                }
                else
                {
                    var claim = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.Email)
                        ,new Claim("IsAdmin",user.IsAdmin.ToString())
                      //  new Claim("any name",any value)
                    };

                    var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var propeties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };

                    HttpContext.SignInAsync(principal, propeties);

                    return Redirect("/");
                }
            }
            return View(login);
        }

        #endregion

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/");
        }
    }
}

