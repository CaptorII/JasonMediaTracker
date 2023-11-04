using System;
using System.Collections.Generic;
using System.Text;

namespace JasonMediaTracker.Models
{
    public class Movie : Media
    {
        private int releaseYear;
        public new Movie[] uncompleted;
        public new Movie[] unreleased;
        public new Movie[] completed;

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
