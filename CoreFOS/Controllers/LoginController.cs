using Microsoft.AspNetCore.Mvc;
using CFOS.ServiceLayer.Concretes.dotnetCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CoreFOS.Controllers
{
    public class LoginController : Controller
    {
        AdminService adminService = new AdminService();
        CalisanService calisanService = new CalisanService();
        UserService userService = new UserService();
        public static string viewStringController, viewStringView, RouteEmail;
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View("~/Views/Login/LoginView.cshtml");
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Check(string username, string password)
        {
            try
            {
                
                var claims = new List<Claim>();
                bool check=false;
                if (check != adminService.adminLogin(username, password).Item3)
                { 
                    claims.Add(new Claim(ClaimTypes.Email, username));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrencipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrencipal);
                    viewStringController = adminService.adminLogin(username, password).Item1;
                    viewStringView = adminService.adminLogin(username, password).Item2;
                    RouteEmail = username;
                }
                else
                {
                    if (check != calisanService.Login(username, password).Item3)
                    {
                        claims.Add(new Claim(ClaimTypes.Email, username));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                        claims.Add(new Claim(ClaimTypes.Role, "Yetkili"));
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrencipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrencipal);
                        viewStringController = calisanService.Login(username, password).Item1;
                        viewStringView = calisanService.Login(username, password).Item2;
                        RouteEmail = username;
                    }
                    else if (check != userService.UserLogin(username, password).Item3)
                    {
                        claims.Add(new Claim(ClaimTypes.Email, username));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                        claims.Add(new Claim(ClaimTypes.Role, "User"));
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrencipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrencipal);

                        viewStringController = userService.UserLogin(username, password).Item1;
                        viewStringView = userService.UserLogin(username, password).Item2;
                        RouteEmail = username;
                    }
                    else
                        RouteEmail = null;
                }

                if(RouteEmail == null) 
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    return RedirectToAction(viewStringView, viewStringController, new { email = RouteEmail });
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
