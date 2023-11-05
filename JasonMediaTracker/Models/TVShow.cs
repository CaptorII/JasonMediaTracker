using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JasonMediaTracker.Models
{
    public class TVShow : Media
    {
        private int initialReleaseYear;
        private int yearCompleted;
        public static new ObservableCollection<TVShow> uncompleted = new ObservableCollection<TVShow>();
        public static new ObservableCollection<TVShow> unreleased = new ObservableCollection<TVShow>();
        public static new ObservableCollection<TVShow> completed = new ObservableCollection<TVShow>();

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
