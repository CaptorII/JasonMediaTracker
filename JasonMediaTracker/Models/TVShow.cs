using System;
using System.Collections.Generic;
using System.Text;

namespace JasonMediaTracker.Models
{
    internal class TVShow : Media
    {
        private int initialReleaseYear;
        private int yearCompleted;
        public new TVShow[] uncompleted;
        public new TVShow[] unreleased;
        public new TVShow[] completed;

        public TVShow(string title) 
        {
            this.title = title;
        }

        public TVShow(string title, int initialReleaseYear)
        {
            this.title = title;
            this.initialReleaseYear = initialReleaseYear;
        }

        public TVShow(string title, int initialReleaseYear, int yearCompleted) 
        {
            this.title = title;
            this.initialReleaseYear = initialReleaseYear;
            this.yearCompleted = yearCompleted;
        }

        public TVShow(string title, DateTime releaseDate)
        {
            this.title = title;
            this.releaseDate = releaseDate;
        }
    }
}
