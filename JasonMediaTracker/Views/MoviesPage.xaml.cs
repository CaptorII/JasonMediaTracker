using JasonMediaTracker.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JasonMediaTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        Movie movie = new Movie("");
        public MoviesPage()
        {
            InitializeComponent();
        }

        private async void AddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AddPage(movie)));
        }
    }
}