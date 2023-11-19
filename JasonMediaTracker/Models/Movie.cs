using System;

namespace JasonMediaTracker.Models
{
    public class Movie : Media
    {
        public int releaseYear;

        public Movie() { }

        public Movie(string title)
        {
            this.title = title;
        }

        public Movie(string title, int releaseYear)
        {
            this.title = title;
            this.releaseYear = releaseYear;
        }

        public Movie(string title, DateTime releaseDate)
        {
            this.title = title;
            this.releaseDate = releaseDate;
        }
    }
}
