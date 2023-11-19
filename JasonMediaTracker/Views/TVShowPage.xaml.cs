using JasonMediaTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JasonMediaTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TVShowPage : ContentPage
    {
        TVShow tvShow = new TVShow("");
        public TVShowPage()
        {
            InitializeComponent();
        }

        private async void AddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AddPage(tvShow)));
        }
    }
}