using JasonMediaTracker.Models;
using JasonMediaTracker.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JasonMediaTracker.ViewModels
{
    public static class AddViewModel
    {
        public static Media CreateMedia(Media m, string title, string label2 = "", string completedYearStr = "", string releaseDateStr = "")
        {
            DateTime releaseDate;
            bool releaseDateExists = DateTime.TryParse(releaseDateStr, out releaseDate);
            int releaseYear, completedYear;
            bool releaseYearExists = int.TryParse(label2, out releaseYear);
            bool completedYearExists = int.TryParse(completedYearStr, out completedYear);
            if (releaseDateExists)
            {
                if (m.GetType() == typeof(Book))
                {
                    Book book = new Book(title, label2, releaseDate);
                    return book;
                }
                else if (m.GetType() == typeof(Movie))
                {
                    Movie movie = new Movie(title, releaseDate);
                    return movie;
                }
                else
                {
                    TVShow tvShow = new TVShow(title, releaseDate);
                    return tvShow;
                }
            } else
            {
                if (m.GetType() == typeof(Book))
                {
                    Book book = new Book(title, label2);
                    return book;
                }
                else if (m.GetType() == typeof(Movie))
                {
                    Movie movie = new Movie(title, releaseYear);
                    return movie;
                }
                else
                {
                    if (releaseYearExists && completedYearExists)
                    {
                        TVShow tvShow = new TVShow(title, releaseYear, completedYear);
                        return tvShow;
                    } 
                    else if (releaseYearExists)
                    {
                        TVShow tvShow = new TVShow(title, releaseYear);
                        return tvShow;
                    } 
                    else
                    {
                        TVShow tvShow = new TVShow(title);
                        return tvShow;
                    }
                }
            }
        }
    }
}
