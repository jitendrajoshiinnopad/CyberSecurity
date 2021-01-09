using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberSecurity.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static CyberSecurity.Areas.Identity.Pages.Account.LoginModel;

namespace CyberSecurity.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<UserController> _logger;


        public UserController(SignInManager<IdentityUser> signInManager,            
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            UserViewModels _objUserViewModels = new UserViewModels();
            return View(_objUserViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModels _objUserViewModels)
        {
            var result = await _signInManager.PasswordSignInAsync(_objUserViewModels.Email, _objUserViewModels.Password, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            if (result.RequiresTwoFactor)
            {
                // return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return RedirectToPage("./Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }
           
        }
        //[HttpPost]
        public async Task<IActionResult> OnPostAsync(UserViewModels _objUserViewModels)
        {
            try
            {
                _objUserViewModels.Email = "joshi@mail.com";
                _objUserViewModels.Password = "Joshi@123";
                // var user =await _userManager.FindByEmailAsync(_objUserViewModels.Email);

                // returnUrl = returnUrl ?? Url.Content("~/");

                if (ModelState.IsValid)
                {
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    var result = await _signInManager.PasswordSignInAsync(_objUserViewModels.Email, _objUserViewModels.Password, true, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        // return LocalRedirect(returnUrl);
                    }
                    if (result.RequiresTwoFactor)
                    {
                        // return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View();
                    }
                }

                // If we got this far, something failed, redisplay form
                return View();
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "User");
        }

    }
}