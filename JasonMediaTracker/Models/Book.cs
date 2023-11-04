using System;

namespace JasonMediaTracker.Models
{
    public class Book : Media
    {
        private string author;
        public new Book[] uncompleted;
        public new Book[] unreleased;
        public new Book[] completed;

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
