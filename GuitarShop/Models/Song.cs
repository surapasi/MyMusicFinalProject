using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyMusic.Models
{
    public class Song

    {
        // EF will instruct the database to automatically generate this value
        public int SongID { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryID { get; set; }  // foreign key property

        public Category Category { get; set; }

        [Required(ErrorMessage = "Please enter the song name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the artist name.")]
        public string Artist { get; set; }

        public string Slug {
            get {
                if (Name == null)
                    return "";
                else
                    return Name.Replace(' ', '-');
            }
        }
    }
}