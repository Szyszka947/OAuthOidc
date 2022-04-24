using Microsoft.AspNetCore.Mvc;
using OAuthOidc.Handlers.AccountEndpoint;
using OAuthOidc.ViewModels;

namespace OAuthOidc.Controllers
{
    [Route("[controller]")]
    [Controller]
    public class AccountController : Controller
    {
        private readonly ISignInHandler _signInHandler;
        private readonly ISignOnHandler _signOnHandler;

        public AccountController(ISignInHandler signInHandler, ISignOnHandler signOnHandler)
        {
            _signInHandler = signInHandler;
            _signOnHandler = signOnHandler;
        }

        //GET account/login
        [HttpGet("login", Name = "GETlogin")]
        public IActionResult SignInView() => View("SignIn");

        //GET account/register
        [HttpGet("register")]
        public IActionResult SignOnView() => View("SignOn");


        //POST account/login
        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn([FromForm] SignInViewModel signInViewModel, string returnUrl)
        {
            var result = await _signInHandler.SignInAsync(signInViewModel, HttpContext);

            if (result) return Redirect(returnUrl);
            else
            {
                ViewData["Error"] = "* E-mail or password is incorrect";
                return View(signInViewModel);
            }
        }

        //POST account/register
        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOn([FromForm] SignOnViewModel signOnViewModel)
        {
            if (await _signOnHandler.SignOnAsync(signOnViewModel, HttpContext, ModelState) == false)
                return View(signOnViewModel);

            return RedirectToRoute("GETlogin");
        }
    }
}
