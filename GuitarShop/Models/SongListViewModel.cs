using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.Models
{
    public class SongListViewModel
    {

        public List<Category> Categories { get; set; }
        public List<Song> Songs { get; set; }
        public string SelectedCategory { get; set; }
        public string CheckActiveCategory(string category) =>
            category == SelectedCategory ? "active" : "";

    }
}
