using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JasonMediaTracker.Models
{
    public class Book : Media
    {
        private string author;
        public static new ObservableCollection<Book> uncompleted = new ObservableCollection<Book>();
        public static new ObservableCollection<Book> unreleased = new ObservableCollection<Book>();
        public static new ObservableCollection<Book> completed = new ObservableCollection<Book>();

        public Book(string title)
        {
            this.title = title;
        }

        public Book(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        public Book(string title, string author, DateTime releaseDate)
        {
            this.title = title;
            this.author = author;
            this.releaseDate = releaseDate;
        }
    }
}
