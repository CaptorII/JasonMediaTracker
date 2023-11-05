using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JasonMediaTracker.Models
{
    public class Movie : Media
    {
        private int releaseYear;
        public static new ObservableCollection<Movie> uncompleted = new ObservableCollection<Movie>();
        public static new ObservableCollection<Movie> unreleased = new ObservableCollection<Movie>();
        public static new ObservableCollection<Movie> completed = new ObservableCollection<Movie>();

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
