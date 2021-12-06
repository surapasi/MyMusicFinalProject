using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMusic.Models;

namespace MyMusic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SongController : Controller
    {
        private ShopContext context;
        private List<Category> categories;

        public SongController(ShopContext ctx)
        {
            context = ctx;
            categories = context.Categories
                    .OrderBy(c => c.CategoryID)
                    .ToList();
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            List<Song> songs;
            if (id == "All")
            {
                songs = context.Songs
                    .OrderBy(p => p.SongID).ToList();
            }
            else
            {
                songs = context.Songs
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.SongID).ToList();
            }

            // use ViewBag to pass category data to view
            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;

            // bind songs to view
            return View(songs);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // create new song object
            Song song = new Song();                // create song object
            song.Category = context.Categories.Find(1);  // add Category object - prevents validation problem

            // use ViewBag to pass action and category data to view
            ViewBag.Action = "Add";
            ViewBag.Categories = categories;

            // bind song to AddUpdate view
            return View("AddUpdate", song);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            // get Song object for specified primary key
            Song song = context.Songs
                .Include(p => p.Category)
                .FirstOrDefault(p => p.SongID == id);

            // use ViewBag to pass action and category data to view
            ViewBag.Action = "Update";
            ViewBag.Categories = categories;

            // bind song to AddUpdate view
            return View("AddUpdate", song);
        }

        [HttpPost]
        public IActionResult Update(Song song)
        {
            if (ModelState.IsValid)
            {
                if (song.SongID == 0)           // new song
                {
                    context.Songs.Add(song);
                    TempData["UserMessage"] = "You just added the song SongName";
                    ViewBag.userMessage = TempData["UserMessage"];
                }
                else                                  // existing song
                {
                    context.Songs.Update(song);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", song);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Song song = context.Songs
                .FirstOrDefault(p => p.SongID == id);
            return View(song);
        }

        [HttpPost]
        public IActionResult Delete(Song song)
        {
            context.Songs.Remove(song);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}