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
        public IActionResult About()

        {

            return View();
        }
        public IActionResult Categories()

        {
            var categories = db.Categories.ToList();
            if (categories == null)
            {
                return NotFound(); // or handle as needed
            }

            return View(categories);
        }
        [HttpPost]
        public IActionResult saveContact(ContactUS model)

        {
			db.Add(model);
			db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteNews(int  id)

        {
            var result = db.News.Find(id);
            db.Remove(result);
            db.SaveChanges();
            return RedirectToAction("NewsofCategory");
        }
        public IActionResult Messages()

        {
			
            return View(db.ContactUs.ToList());
        }
        public IActionResult NewsOfCategory(int id)

        {
            Categories categories = db.Categories.Find(id);
            ViewBag.CategoryName = categories.Name;
            ViewBag.CategoryDesc = categories.Description;
			var result = db.News.Where( e => e.CategoryId == id ).ToList();
            return View(result);
        }
        public IActionResult ReadMore(int id)

        {
            News news = db.News.Find(id);
            ViewBag.News = news;
 
            return View("ReadMore");
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
