using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using news_websites.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace news_websites.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsContext db;
        private readonly IHostingEnvironment _host;

        public NewsController(NewsContext context, IHostingEnvironment host)
        {
            db = context;
            _host = host;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            var newsContext = db.News.Include(n => n.Category);
            return View(await newsContext.ToListAsync());
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || db.News == null)
            {
                return NotFound();
            }

            var news = await db.News
                .Include(n => n.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            @ViewBag.News = news.Title;
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Topic,Date,clientFile,Description,CategoryId,clientFile")] News news)
        {
            var Cat = db.Categories.Find(news.CategoryId);
            if (Cat != null)
            {
                news.Category = Cat;
            }
            string fileName = string.Empty;

            if (ModelState.IsValid)
            {
                if (news.clientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "assets\\img");
                    fileName = Path.GetFileName(news.clientFile.FileName);
                    string fullpath = Path.Combine(myUpload, fileName);
                    using (var stream = new FileStream(fullpath, FileMode.Create))
                    {
                        await news.clientFile.CopyToAsync(stream);
                    }
                    news.image = fileName;
                }
                else
                {
                    news.image = "noImg.png";
                }
                db.Add(news);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", news.CategoryId);
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.News == null)
            {
                return NotFound();
            }

            var news = await db.News.FindAsync(id);
            @ViewBag.News = news.Title;

            if (news == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", news.CategoryId);
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Topic,Date,clientFile,Description,CategoryId")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingNews = await db.News.FindAsync(id);
                    if (existingNews == null)
                    {
                        return NotFound();
                    }

                    // Update the fields
                    existingNews.Title = news.Title;
                    existingNews.Topic = news.Topic;
                    existingNews.Date = news.Date;
                    existingNews.Description = news.Description;
                    existingNews.CategoryId = news.CategoryId;

                    // If a new file is chosen, update the image
                    if (news.clientFile != null)
                    {
                        string myUpload = Path.Combine(_host.WebRootPath, "assets\\img");
                        string fileName = Path.GetFileName(news.clientFile.FileName);
                        string fullpath = Path.Combine(myUpload, fileName);
                        using (var stream = new FileStream(fullpath, FileMode.Create))
                        {
                            await news.clientFile.CopyToAsync(stream);
                        }
                        existingNews.image = fileName;
                    }

                    db.Update(existingNews);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", news.CategoryId);
            return View(news);
        }
        public IActionResult DeleteImg(string name,int id)
        {
            if (string.IsNullOrEmpty(name))
            {
                return NotFound();
            }

            // Path to the image
            string imagePath = Path.Combine(_host.WebRootPath, "assets\\img", name);

            // Check if the image exists and delete it
            if (System.IO.File.Exists(imagePath))
            {
                var newsItem =  db.News.Find(id);
                if (newsItem != null)
                {
                    newsItem.image = "noImg.png";
                    db.Update(newsItem);
                     db.SaveChanges();
                }

            }
                return RedirectToAction("Edit", new { id });

        }
        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.News == null)
            {
                return NotFound();
            }

            var news = await db.News
                .Include(n => n.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            @ViewBag.News = news.Title;

            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.News == null)
            {
                return Problem("Entity set 'NewsContext.News'  is null.");
            }
            var news = await db.News.FindAsync(id);
            @ViewBag.News = news.Title;

            if (news != null)
            {
                db.News.Remove(news);
            }

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return (db.News?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
