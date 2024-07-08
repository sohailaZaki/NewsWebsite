using Microsoft.AspNetCore.Mvc;
using news_websites.Models;
using System.Diagnostics;

namespace news_websites.Controllers
{
	public class HomeController : Controller
	{
		NewsContext db { get; set; }
	

        private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, NewsContext context)
		{
			_logger = logger;
            db = context;
        }

		public IActionResult Index()

		{
		var result =  	db.Categories.ToList();
			return View(result);
		}
        public IActionResult ContactUs()

        {
           
            return View();
        }
		[HttpPost]
        public IActionResult saveContact(ContactUS model)

        {
			db.Add(model);
			db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Messages()

        {
			
            return View(db.ContactUs.ToList());
        }
        public IActionResult NewsOfCategory(int id)

        {
			var result = db.News.Where( e => e.CategoryId == id ).ToList();
            return View(result);
        }
        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
