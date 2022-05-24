using Microsoft.AspNetCore.Mvc;
using CFOS.EntityLayer.Concretes;
using CFOS.ServiceLayer.Concretes.dotnetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace CoreFOS.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        UserService userService = new UserService();
        AdminService AdminService = new AdminService();
        List<Order> Orders = new List<Order>();
        Order Order = new Order();
        public static string Email;

        public IActionResult Index(string email)
        {
            Email = email;
            return View("~/Views/User/UserPanel.cshtml");
        }
        public IActionResult AddOrder()
        {
            return View("~/Views/User/AddOrder.cshtml");
        }
        public IActionResult DeleteOrder(int OrderId,int UserId)
        {
            UserId = (int)TempData["UserTempId"];
            TempData.Keep();
            Orders = userService.getOrderByUserId(UserId);
            ViewBag.OrderList = Orders;
            userService.deleteOrder(OrderId);

            return View("~/Views/User/DeleteOrder.cshtml");
        }
        public IActionResult ListOrder(int OrderId, int UserId)
        {
            UserId = (int)TempData["UserTempId"];
            TempData.Keep();
            Orders = userService.getOrderByUserId(UserId);
            ViewBag.OrderList = Orders;
            return View("~/Views/User/ListOrder.cshtml");
        }
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync();
                return View("~/Views/Login/LoginView.cshtml");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public IActionResult UpdateOrder(int OrderId, int UserId)
        {
            UserId = (int)TempData["UserTempId"];
            TempData.Keep();
            Orders = userService.getOrderByUserId(UserId);
            ViewBag.OrderList = Orders;
            return View("~/Views/User/UpdateOrder.cshtml");
        }
        public IActionResult myProfile()
        {
            return View("~/Views/User/myProfile.cshtml");
        }
    }
}
