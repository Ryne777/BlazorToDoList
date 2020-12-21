using System.Threading.Tasks;
using BlazorToDoList.ViewModels.AccountViewModels;
using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorToDoList.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class IdentificationController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly UserManager<ApplicationUser> _userManager;

        public IdentificationController(
            IIdentityServerInteractionService interaction)
        //SignInManager<ApplicationUser> signInManager,
        //UserManager<ApplicationUser> userManager)
        {
            _interaction = interaction;
            //_signInManager = signInManager;
            //_userManager = userManager;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Login(string returnUrl)
        {
            return View();
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please. Validate your credentials and try again.");
                return View(model);
            }

            if (model.UserName != "my.email.ru")
            {
                ModelState.AddModelError("", "Not found.");
                return View(model);
            }
            await HttpContext.SignInAsync(new IdentityServerUser(model.UserName));



            return Redirect(model.ReturnUrl);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Logout(string logoutId)
        {
            var logout = await _interaction.GetLogoutContextAsync(logoutId);
            await HttpContext.SignOutAsync();
            return Redirect(logout.PostLogoutRedirectUri);
        }
    }
}
