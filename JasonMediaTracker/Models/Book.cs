using System;
using System.Collections.Generic;

namespace JasonMediaTracker.Models
{
    public class Book : Media
    {
        private string author;
        public static new List<Book> uncompleted = new List<Book>();
        public static new List<Book> unreleased = new List<Book>();
        public static new List<Book> completed = new List<Book>();

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
