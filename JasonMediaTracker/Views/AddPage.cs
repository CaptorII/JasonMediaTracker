using JasonMediaTracker.Models;
using JasonMediaTracker.ViewModels;
using System;
using Xamarin.Forms;

namespace JasonMediaTracker.Views
{
    public class AddPage : ContentPage
    {
        public AddPage(Media mediaType)
        {
            FormattedString headerText = new FormattedString();
            FormattedString titleText = new FormattedString();
            FormattedString label2Text = new FormattedString();
            FormattedString releaseText = new FormattedString();
            FormattedString yearCompletedText = new FormattedString();
            Entry titleField = new Entry();
            Entry label2Field = new Entry();
            Entry yearCompletedField = new Entry();
            Entry releaseField = new Entry();
            Button submitButton = new Button { Text = "Add" };
            Button cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += (sender, args) => ReturnToPrevious(mediaType);
            if (mediaType.GetType() == typeof(Book))
            {
                headerText.Spans.Add(new Span { Text = "Add new Book", FontAttributes = FontAttributes.Bold });
                label2Text.Spans.Add(new Span { Text = "Author:", FontAttributes = FontAttributes.Bold });
                submitButton.Clicked += (sender, args) => AddViewModel.CreateMedia((Book)mediaType, titleField.Text, label2Field.Text, releaseField.Text);
            }
            else if (mediaType.GetType() == typeof(Movie))
            {
                headerText.Spans.Add(new Span { Text = "Add new Movie", FontAttributes = FontAttributes.Bold });
                label2Text.Spans.Add(new Span { Text = "Release Year:", FontAttributes = FontAttributes.Bold });
                submitButton.Clicked += (sender, args) => AddViewModel.CreateMedia((Movie)mediaType, titleField.Text, label2Field.Text, releaseField.Text);
            }
            else if (mediaType.GetType() == typeof(TVShow))
            {
                headerText.Spans.Add(new Span { Text = "Add new TV Show", FontAttributes = FontAttributes.Bold });
                label2Text.Spans.Add(new Span { Text = "Initial Release Year:", FontAttributes = FontAttributes.Bold });
                yearCompletedText.Spans.Add(new Span { Text = "Year Completed:", FontAttributes = FontAttributes.Bold });
                submitButton.Clicked += (sender, args) => AddViewModel.CreateMedia((TVShow)mediaType, titleField.Text, label2Field.Text, yearCompletedField.Text, releaseField.Text);
            }
            titleText.Spans.Add(new Span { Text = "Title:", FontAttributes = FontAttributes.Bold });
            releaseText.Spans.Add(new Span { Text = "Release Date:", FontAttributes = FontAttributes.Bold });
            Label header = new Label { FormattedText = headerText, HorizontalTextAlignment = TextAlignment.Center };
            Label titleLabel = new Label { FormattedText = titleText };
            Label label2 = new Label { FormattedText = label2Text };
            Label yearCompletedLabel = new Label { FormattedText = yearCompletedText };
            Label releaseLabel = new Label { FormattedText = releaseText };
            if (mediaType.GetType() == typeof(Book) | mediaType.GetType() == typeof(Movie))
            {
                Content = new StackLayout
                {
                    Children = {
                    header,
                    titleLabel,
                    titleField,
                    label2,
                    label2Field,
                    releaseLabel,
                    releaseField,
                    new StackLayout { Orientation = StackOrientation.Horizontal, Children = { submitButton, cancelButton }}
                }
                };
            }
            else if (mediaType.GetType() == typeof(TVShow))
            {
                Content = new StackLayout
                {
                    Children = {
                    header,
                    titleLabel,
                    titleField,
                    label2,
                    label2Field,
                    yearCompletedLabel,
                    yearCompletedField,
                    releaseLabel,
                    releaseField,
                    new StackLayout { Orientation = StackOrientation.Horizontal, Children = { submitButton, cancelButton }}
                }
                };
            }
        }

        public async void ReturnToPrevious(Media m)
        {
            if (m.GetType() == typeof(Book))
            {
                await Navigation.PushAsync(new NavigationPage(new BooksPage()));
            }
            else if (m.GetType() == typeof(Movie))
            {
                await Navigation.PushAsync(new NavigationPage(new MoviesPage()));
            } 
            else if (m.GetType() == typeof(TVShow))
            {
                await Navigation.PushAsync(new NavigationPage(new TVShowsPage()));
            }
        }
    }
}