using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Models;

namespace MyMusic.Controllers
{
    public class SongController : Controller
    {
        private ShopContext context;

        public SongController(ShopContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Song");
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryID).ToList();

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

            var model = new SongListViewModel
            {
                Categories = categories,
                Songs = songs,
                SelectedCategory = id
            };

            // bind model to view
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryID).ToList();

            Song song = context.Songs.Find(id);


            // use ViewBag to pass data to view
            ViewBag.Categories = categories;

            // bind song to view
            return View(song);
        }
    }
}