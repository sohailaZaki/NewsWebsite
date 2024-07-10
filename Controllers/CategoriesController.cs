using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using news_websites.Models;

namespace news_websites.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly NewsContext db;

        public CategoriesController(NewsContext context)
        {
            db = context;
        }

        // GET: Categories
        public IActionResult Index()
        {
              return db.Categories != null ? 
                          View( db.Categories.ToList()) :
                          Problem("Entity set 'NewsContext.Categories'  is null.");
        }

        // GET: Categories/Details/5
        public  IActionResult Details(int? id)
        {
            if (id == null || db.Categories == null)
            {
                return NotFound();
            }

            var categories =  db.Categories
                .Find( id);
            ViewBag.Cat = categories.Name;
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CategoryId,Name,Description")] Categories categories)
        {
            categories.News = new List<News>();
            if (ModelState.IsValid)
            {
                db.Add(categories);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Log the model state errors
            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            return View(categories);
        }

        // GET: Categories/Edit/5
        public  IActionResult  Edit(int? id)
        {
            if (id == null || db.Categories == null)
            {
                return NotFound();
            }

            var categories =   db.Categories.Find(id);
            ViewBag.Cat = categories.Name;
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult  Edit(int id, [Bind("Id,CategoryId,Name,Description,CategoryCount,CategoriesCount")] Categories categories)
        {
            if (id != categories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(categories);
                      db.SaveChanges();
                    ViewBag.Cat = categories.Name;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesExists(categories.Id))
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
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View(categories);
        }

        // GET: Categories/Delete/5
        public  IActionResult  Delete(int? id)
        {
            if (id == null || db.Categories == null)
            {
                return NotFound();
            }

            var categories =   db.Categories
                .Find( id);
            ViewBag.Cat = categories.Name;
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult  DeleteConfirmed(int id)
        {
            if (db.Categories == null)
            {
                return Problem("Entity set 'NewsContext.Categories'  is null.");
            }
            var categories =   db.Categories.Find(id);
            if (categories != null)
            {
                ViewBag.Cat = categories.Name;
                db.Categories.Remove(categories);
         

            }
            
              db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriesExists(int id)
        {
          return (db.Categories?.Any(e =>  e.Id == id)).GetValueOrDefault();
        }
    }
}
