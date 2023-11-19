using System;

namespace JasonMediaTracker.Models
{
    public class Book : Media
    {
        public string author { get; set; }

        public Book() { }

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
