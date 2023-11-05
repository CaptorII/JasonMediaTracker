using System;
using System.Collections.Generic;

namespace JasonMediaTracker.Models
{
    public class Movie : Media
    {
        private int releaseYear;
        public static new List<Movie> uncompleted = new List<Movie>();
        public static new List<Movie> unreleased = new List<Movie>();
        public static new List<Movie> completed = new List<Movie>();

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
