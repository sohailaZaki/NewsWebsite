using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using news_websites.Models;

namespace news_websites.Views.Categories
{
    public class NewsController : Controller
    {
        private readonly NewsContext db;

        public NewsController(NewsContext context)
        {
            db = context;
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
        public async Task<IActionResult> Create([Bind("Id,Title,Topic,Date,imageUrl,Description,CategoryId")] News news)
        {
           var Cat = db.Categories.Find(news.CategoryId);
            if (Cat != null)
            {
                news.Category = Cat;
            }
                if (ModelState.IsValid) {
                    db.Add(news);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", news.CategoryId);
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Topic,Date,imageUrl,Description,CategoryId")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

         if(ModelState.IsValid) { 
                try
                {
                    db.Update(news);
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
