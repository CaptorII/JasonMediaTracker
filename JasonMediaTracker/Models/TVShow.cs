using System;

namespace JasonMediaTracker.Models
{
    public class TVShow : Media
    {
        public int initialReleaseYear, yearCompleted;

        public TVShow() { }

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
