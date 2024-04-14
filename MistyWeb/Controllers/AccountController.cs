using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using misty.Models;

namespace MistyWeb.Controllers {
    public class AccountController : Controller {
        private readonly Microsoft.AspNetCore.Identity.SignInManager<AppUser> _SignInManager;
        private readonly UserManager<AppUser> _userManager;


        public AccountController(SignInManager<AppUser> SignInManager, UserManager<AppUser> userManager) {
            _SignInManager = SignInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login) {
            if (ModelState.IsValid) {
                var result = await _SignInManager.PasswordSignInAsync(login.Username, login.Password, login.RememberMe, false);
                if (result.Succeeded) {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "invalid login");
                return View(login);
            }

              
                return View(login);
            

        }

        public IActionResult Registre() {
            return View();
        }




        public IActionResult Login() {
            return View();
        
        }

       
        [HttpPost]
        public async Task<IActionResult> Register(Registre registre) {
            AppUser user = new() {
                name = registre.Name,
                UserName = registre.Email,
                Email = registre.Email,
                adresse = registre.Address,
            };
            var result = await _userManager.CreateAsync(user, registre.Password); 
            if(result.Succeeded) {
                await _SignInManager.SignInAsync(user, false); 
                return RedirectToAction("Index", "Home"); 
            }
            else {
                return View(registre);
            }
        }

        public async Task<IActionResult> Logout() {
            await _SignInManager.SignOutAsync(); 
            return RedirectToAction("Index", "Home");
        }
    }
}
