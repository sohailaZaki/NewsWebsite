using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using news_websites.Models;

namespace news_websites.Controllers
{
    public class AdminDashboard : Controller
    {
        [Authorize(Roles = Roles.roleAdmin)]

        public IActionResult Index()

        {

            return View();
        }
        public IActionResult Charts()

        {

            return View();
        }
    }
}
