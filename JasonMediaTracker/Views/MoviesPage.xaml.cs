using JasonMediaTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JasonMediaTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        Movie movie = new Movie();
        ObservableCollection<Movie> uncompletedMovies, unreleasedMovies, completedMovies;

        public MoviesPage()
        {
            InitializeComponent();
            uncompletedMovies = new ObservableCollection<Movie>();
            unreleasedMovies = new ObservableCollection<Movie>();
            completedMovies = new ObservableCollection<Movie>();
            Database.InitialiseDatabase();
            InitialiseMovies();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshMovies();
        }

        public async void InitialiseMovies()
        {
            while (!Database.IsInitialized)
            {
                await Task.Delay(100); // delay and check again until the database is initialized
            }
            RefreshMovies();
            UncompletedList.ItemsSource = uncompletedMovies;
            UnreleasedList.ItemsSource = unreleasedMovies;
            CompletedList.ItemsSource = completedMovies;
        }

        private void RefreshMovies()
        {
            uncompletedMovies.Clear();
            unreleasedMovies.Clear();
            completedMovies.Clear();
            List<Movie> allMovies = Database.db.Table<Movie>().ToListAsync().Result;
            foreach (Movie movie in allMovies)
            {
                if (movie.releaseDate > DateTime.Today) // if release date is in the future
                {
                    unreleasedMovies.Add(movie);
                }
                else if (movie.isCompleted)
                {
                    completedMovies.Add(movie);
                }
                else
                {
                    uncompletedMovies.Add(movie);
                }
            }
        }

        private async void MarkCompleted(object sender, ToggledEventArgs e)
        {
            if (sender is Switch toggleSwitch && toggleSwitch.BindingContext is Movie movie)
            {
                if (!toggleSwitch.IsToggled) return; // prevents method running every time lists are refreshed

                movie.isCompleted = true;
                Database.UpdateTable(movie);
                while (!Database.OperationCompleted)
                {
                    await Task.Delay(100); // delay and check again until the task is completed
                }
                RefreshMovies();
            }
        }

        private async void MarkIncomplete(object sender, ToggledEventArgs e)
        {
            if (sender is Switch toggleSwitch && toggleSwitch.BindingContext is Movie movie)
            {
                if (toggleSwitch.IsToggled) return; // prevents method running every time lists are refreshed

                movie.isCompleted = false;
                Database.UpdateTable(movie);
                while (!Database.OperationCompleted)
                {
                    await Task.Delay(100); // delay and check again until the task is completed
                }
                RefreshMovies();
            }
        }

        private async void AddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AddPage(movie)));
        }
    }

}