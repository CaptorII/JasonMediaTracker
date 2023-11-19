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
    public partial class TVShowPage : ContentPage
    {
        TVShow show = new TVShow("");
        ObservableCollection<TVShow> uncompletedShows, unreleasedShows, completedShows;

        public TVShowPage()
        {
            InitializeComponent();
            uncompletedShows = new ObservableCollection<TVShow>();
            unreleasedShows = new ObservableCollection<TVShow>();
            completedShows = new ObservableCollection<TVShow>();
            Database.InitialiseDatabase();
            InitialiseShows();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshShows();
        }

        public async void InitialiseShows()
        {
            while (!Database.IsInitialized)
            {
                await Task.Delay(100); // delay and check again until the database is initialized
            }
            RefreshShows();
            UncompletedList.ItemsSource = uncompletedShows;
            UnreleasedList.ItemsSource = unreleasedShows;
            CompletedList.ItemsSource = completedShows;
        }

        private void RefreshShows()
        {
            uncompletedShows.Clear();
            unreleasedShows.Clear();
            completedShows.Clear();
            List<TVShow> allShows = Database.db.Table<TVShow>().ToListAsync().Result;
            foreach (TVShow show in allShows)
            {
                if (show.releaseDate > DateTime.Today) // if release date is in the future
                {
                    unreleasedShows.Add(show);
                }
                else if (show.isCompleted)
                {
                    completedShows.Add(show);
                }
                else
                {
                    uncompletedShows.Add(show);
                }
            }
        }

        private async void MarkCompleted(object sender, ToggledEventArgs e)
        {
            if (sender is Switch toggleSwitch && toggleSwitch.BindingContext is TVShow show)
            {
                if (!toggleSwitch.IsToggled) return; // prevents method running every time lists are refreshed

                show.isCompleted = true;
                Database.UpdateTable(show);
                while (!Database.OperationCompleted)
                {
                    await Task.Delay(100); // delay and check again until the task is completed
                }
                RefreshShows();
            }
        }

        private async void MarkIncomplete(object sender, ToggledEventArgs e)
        {
            if (sender is Switch toggleSwitch && toggleSwitch.BindingContext is TVShow show)
            {
                if (toggleSwitch.IsToggled) return; // prevents method running every time lists are refreshed

                show.isCompleted = false;
                Database.UpdateTable(show);
                while (!Database.OperationCompleted)
                {
                    await Task.Delay(100); // delay and check again until the task is completed
                }
                RefreshShows();
            }
        }

        private async void AddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AddPage(show)));
        }
    }

}