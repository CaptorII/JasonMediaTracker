using JasonMediaTracker.Models;
using JasonMediaTracker.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JasonMediaTracker.ViewModels
{
    public class AddViewModel : ContentPage
    {
        public void CreateMedia(Book book, string title, string author = "", string releaseDateStr = "")
        {
            DateTime releaseDate;
            bool releaseDateExists = DateTime.TryParse(releaseDateStr, out releaseDate);
            if (releaseDateExists)
            {
                Book newBook = new Book(title, author, releaseDate);
                if (releaseDate < DateTime.Now)
                {
                    Book.uncompleted.Add(newBook);
                } 
                else
                {
                    Book.unreleased.Add(newBook);
                }
            } 
            else
            {
                Book newBook = new Book(title, author);
                Book.uncompleted.Add(newBook);
            }
            Shell.Current.Navigation.PopAsync();
        }
        public void CreateMedia(Movie movie, string title, string releaseYearStr = "", string releaseDateStr = "")
        {
            DateTime releaseDate;
            bool releaseDateExists = DateTime.TryParse(releaseDateStr, out releaseDate);
            int releaseYear;
            bool releaseYearExists = int.TryParse(releaseYearStr, out releaseYear);
            if (releaseDateExists)
            {
                Movie newMovie = new Movie(title, releaseDate);
                if (releaseDate < DateTime.Now)
                {
                    Movie.uncompleted.Add(newMovie);
                } 
                else
                {
                    Movie.unreleased.Add(newMovie);
                }
            } 
            else if (releaseYearExists)
            {
                Movie newMovie = new Movie(title, releaseYear);
                Movie.uncompleted.Add(newMovie);
            } 
            else
            {
                Movie newMovie = new Movie(title);
                Movie.uncompleted.Add(newMovie);
            }
            Shell.Current.Navigation.PopAsync();
        }
        public void CreateMedia(TVShow show, string title, string releaseYearStr = "", string completedYearStr = "", string releaseDateStr = "")
        {
            DateTime releaseDate;
            bool releaseDateExists = DateTime.TryParse(releaseDateStr, out releaseDate);
            int releaseYear, completedYear;
            bool releaseYearExists = int.TryParse(releaseYearStr, out releaseYear);
            bool completedYearExists = int.TryParse(completedYearStr, out completedYear);
            if (releaseDateExists)
            {
                TVShow newTVShow = new TVShow(title, releaseDate);
                if (releaseDate < DateTime.Now)
                {
                    TVShow.uncompleted.Add(newTVShow);
                }
                else
                {
                    TVShow.unreleased.Add(newTVShow);
                }
            }
            else if (releaseYearExists && !completedYearExists)
            {
                TVShow newTVShow = new TVShow(title, releaseYear);
                TVShow.uncompleted.Add(newTVShow);
            }
            else if (releaseYearExists && completedYearExists)
            {
                TVShow newTVShow = new TVShow(title, releaseYear, completedYear);
                TVShow.uncompleted.Add(newTVShow);
            }
            else
            {
                TVShow newTVShow = new TVShow(title);
                TVShow.uncompleted.Add(newTVShow);
            }
            Shell.Current.Navigation.PopAsync();
        }
    }
}
