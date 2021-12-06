using Microsoft.EntityFrameworkCore;

namespace MyMusic.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "K-POP" },
                new Category { CategoryID = 2, Name = "R&B" },
                new Category { CategoryID = 3, Name = "Instrumental" }
            );

            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    SongID = 1,
                    CategoryID = 1,
                    Name = "Life Goes On",
                    Artist = "BTS"
                },
                new Song
                {
                    SongID = 2,
                    CategoryID = 1,
                    Name = "Wonderland",
                    Artist = "ATEEZ"
                },
                new Song
                {
                    SongID = 3,
                    CategoryID = 1,
                    Name = "Spring Day",
                    Artist = "BTS"
                },
                new Song
                {
                    SongID = 4,
                    CategoryID = 1,
                    Name = "New Rules",
                    Artist = "TOMORROW X TOGETHER"
                },
                new Song
                {
                    SongID = 5,
                    CategoryID = 1,
                    Name = "Alcohol-Free",
                    Artist = "TWICE"
                },
                new Song
                {
                    SongID = 6,
                    CategoryID = 1,
                    Name = "Middle of the Night",
                    Artist = "MONSTA X"
                },
                new Song
                {
                    SongID = 7,
                    CategoryID = 2,
                    Name = "Woman",
                    Artist = "Doja Cat"
                },
                new Song
                {
                    SongID = 8,
                    CategoryID = 2,
                    Name = "End of the Road",
                    Artist = "Boyz II Men"
                },
                new Song
                {
                    SongID = 9,
                    CategoryID = 3,
                    Name = "Seul Ce Soir",
                    Artist = "Swing 41"
                },
                new Song
                {
                    SongID = 10,
                    CategoryID = 3,
                    Name = "Cake Waltz (Jimin Theme)",
                    Artist = "BTS"
                }
            );
        }
    }
}