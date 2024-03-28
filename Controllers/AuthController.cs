using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Save__plan_your_trips.Models.ViewModels;

namespace Save__plan_your_trips.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AuthController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)

        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequest signUpRequest)
        {
            var identityUser = new IdentityUser
            {
                UserName = signUpRequest.Nickname,
                Email = signUpRequest.Email,
            };

            var identityResult = await userManager.CreateAsync(identityUser, signUpRequest.Password);

            if (identityResult.Succeeded)
            {
                var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "User");

                if (roleIdentityResult.Succeeded)
                    return RedirectToAction("Index", "Home");

            }

            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInRequest signInRequest)
        {

            var signInResult = await signInManager.PasswordSignInAsync
                (signInRequest.Nickname, signInRequest.Password, false, false);

            if (signInResult.Succeeded && signInResult != null)
                return RedirectToAction("Index", "Home");

            return View();
        }
    }
}
