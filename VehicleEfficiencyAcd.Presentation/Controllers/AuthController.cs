using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VehicleEfficiencyAcd.Business.Operations.User;
using VehicleEfficiencyAcd.Business.Operations.User.Dtos;
using VehicleEfficiencyAcd.Presentation.Jwt;
using VehicleEfficiencyAcd.Presentation.Models.Auth;
using LoginRequest = VehicleEfficiencyAcd.Presentation.Models.Auth.LoginRequest;
using RegisterRequest = VehicleEfficiencyAcd.Presentation.Models.Auth.RegisterRequest;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace VehicleEfficiencyAcd.Presentation.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService; // -> Using User Service with dependency injection in ctor
        
        // Dependency injection ctor
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        #region Register - HttpGet
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        #endregion

        #region Register - HttpPost
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest) // -> RegisterRequest is also defined Microsoft.Identity but I used mine for custumization 'Models.RegisterRequest'
        {

            if (!ModelState.IsValid) // -> Checking model states that I defined in Models.RegisterRequest
            {
                return View(registerRequest);
            }

            var addUserDto = new AddUserDto // ->  For transfering request data to my service I used data transfer object that I define in Service-Operation-OperationName-Dtos
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
            };

            var serviceResult = await _userService.AddUser(addUserDto); // -> Calling user service I defined in business layer and sending user as dto

            if (serviceResult.IsSucceed)
            {
                var claims = new List<Claim>();

                claims.Add(new Claim("email", registerRequest.Email));
                claims.Add(new Claim("fullname", registerRequest.FirstName + " " + registerRequest.LastName));

                // ▼ Create a ClaimsIdentity using the list of claims and specifying the authentication scheme ▼
                var claimIdendity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // ▼ Define authentication properties ▼
                var authFeatures = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddHours(1))
                };

                // ▼ Sign the user in with claims, setting the authentication scheme and properties ▼
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdendity), authFeatures);

                // Redirect to a dashboard or home page
                return RedirectToAction("ViewAll", "Vehicle");

            }
            else
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View(registerRequest);
            }
        }
        #endregion

        #region Login - HttpGet
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        #endregion

        #region Login - HttpPost
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid) // -> Checking model states that I defined in Models.LoginRequest
            {
                return View(loginRequest);
            }

            var serviceResult = await _userService.LoginUser(new LoginUserDto { Email = loginRequest.Email, Password = loginRequest.Password }); // -> request to dto, checking credentials on usermanager

            if (serviceResult.IsSucceed)
            {


                var user = serviceResult.Data;

                // ▼ This field for welcome pop in my scenario with logged in appear ▼
                TempData["ShowWelcomeModal"] = true;
                TempData["SuccessMessage"] = $"Welcome, {user.FirstName} {user.LastName}!";

                // ▼ Add user claims email, id and user name & user surname for identify and displaying ▼
                var claims = new List<Claim>();

                claims.Add(new Claim("email", user.Email));
                claims.Add(new Claim("fullname", user.FirstName + " " + user.LastName));
                claims.Add(new Claim(ClaimTypes.Role, user.UserRole.ToString()));

                // ▼ Create a ClaimsIdentity using the list of claims and specifying the authentication scheme ▼
                var claimIdendity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // ▼ Define authentication properties ▼
                var authFeatures = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddHours(1))
                };

                // ▼ Sign the user in with claims, setting the authentication scheme and properties ▼
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdendity), authFeatures);

                TempData["ShowWelcomeModal"] = true;
                TempData["SuccessMessage"] = $"Welcome, {user.FirstName} {user.LastName}!";

                // Redirect to fleet
                return RedirectToAction("ViewAll", "Vehicle");
            }

            else
            {
                ViewBag.ErrorMessage = serviceResult.Message;
                return View(loginRequest);
            }

        }
        #endregion

        #region Logout - HttpPost
        [HttpPost]
        [ValidateAntiForgeryToken] // -> Its useful for CSRF attacks
        public async Task<IActionResult> Logout()
        {
            // Sign out the user by clearing the authentication cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            TempData["ShowWelcomeModal"] = false; // -> I managed welcome message pop up with that logic

            // Redirect to the home page or any other page after logout
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region ▼ I created this for unathourize attemps ▼
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion
    }
}
