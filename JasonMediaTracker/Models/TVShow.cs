using System;
using System.Collections.Generic;

namespace JasonMediaTracker.Models
{
    public class TVShow : Media
    {
        private int initialReleaseYear;
        private int yearCompleted;
        public static new List<TVShow> uncompleted = new List<TVShow>();
        public static new List<TVShow> unreleased = new List<TVShow>();
        public static new List<TVShow> completed = new List<TVShow>();

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
