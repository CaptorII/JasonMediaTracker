using JasonMediaTracker.Models;
using JasonMediaTracker.Views;
using System;
using Xamarin.Forms;

namespace JasonMediaTracker.ViewModels
{
    public class AddViewModel : ContentPage
    {
        public void CreateMedia(Book book, string title, DateTime releaseDate, string author = "")
        {
            Book newBook;
            bool releaseDateExists = releaseDate != DateTime.Today;
            if (releaseDateExists)
            {
                newBook = new Book(title, author, releaseDate);
                Database.db.InsertAsync(newBook);
            } 
            else
            {
                newBook = new Book(title, author);
                Database.db.InsertAsync(newBook);
            }
            Shell.Current.Navigation.PopAsync();
        }
        public void CreateMedia(Movie movie, string title, DateTime releaseDate, string releaseYearStr = "")
        {
            Movie newMovie;
            bool releaseDateExists = releaseDate != DateTime.Today;
            bool releaseYearExists = int.TryParse(releaseYearStr, out int releaseYear);
            if (releaseDateExists)
            {
                newMovie = new Movie(title, releaseDate);
                Database.db.InsertAsync(newMovie);
            } 
            else if (releaseYearExists)
            {
                newMovie = new Movie(title, releaseYear);
                Database.db.InsertAsync(newMovie);
            } 
            else
            {
                newMovie = new Movie(title);
                Database.db.InsertAsync(newMovie);
            }
            Shell.Current.Navigation.PopAsync();
        }
        public void CreateMedia(TVShow show, string title, DateTime releaseDate, string releaseYearStr = "", string completedYearStr = "")
        {
            TVShow newTVShow;
            bool releaseDateExists = releaseDate != DateTime.Today;
            bool releaseYearExists = int.TryParse(releaseYearStr, out int releaseYear);
            bool completedYearExists = int.TryParse(completedYearStr, out int completedYear);
            if (releaseDateExists)
            {
                newTVShow = new TVShow(title, releaseDate);
                Database.db.InsertAsync(newTVShow);
            }
            else if (releaseYearExists && !completedYearExists)
            {
                newTVShow = new TVShow(title, releaseYear);
                Database.db.InsertAsync(newTVShow);
            }
            else if (releaseYearExists && completedYearExists)
            {
                newTVShow = new TVShow(title, releaseYear, completedYear);
                Database.db.InsertAsync(newTVShow);
            }
            else
            {
                newTVShow = new TVShow(title);
                Database.db.InsertAsync(newTVShow);
            }
            Shell.Current.Navigation.PopAsync();
        }
    }
}
