using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MobileCare.Models;
using MobileCare.Models.ViewModels;

namespace MobileCare.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
        )
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);
            try
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

                if (user != null)
                {
                    //User is found, check password
                    var passwordCheck = await _userManager.CheckPasswordAsync(
                        user,
                        loginViewModel.Password
                    );
                    if (passwordCheck)
                    {
                        // Password correct, check role
                        var isCareworker = await _userManager.IsInRoleAsync(user, "Careworker");
                        var isPatient = await _userManager.IsInRoleAsync(user, "Patient");
                        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                        var result = await _signInManager.PasswordSignInAsync(
                            user,
                            loginViewModel.Password,
                            false,
                            false
                        );
                        if (result.Succeeded)
                        {
                            if (isCareworker)
                            {
                                return RedirectToAction(
                                    "GetBooking",
                                    "Careworker",
                                    new { id = user.Id }
                                );
                            }
                            if (isPatient)
                            {
                                return RedirectToAction("Index", "Patient", new { id = user.Id });
                            }

                            if (isAdmin)
                            {
                                return RedirectToAction("Index", "Admin", new { id = user.Id });
                            }
                        }
                        else
                        {
                            TempData["Error"] =
                                "You do not have the required role to access this resource.";
                            return View(loginViewModel);
                        }
                    }

                    TempData["Error"] = "Wrong credentials. Please try again";
                    return View(loginViewModel);
                }
                //User not found
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(loginViewModel);
            }
            catch (SqlException)
            {
                TempData["Error"] =
                    "There has been a problem accessing the database. Please try logging in again.";
                return View(loginViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
