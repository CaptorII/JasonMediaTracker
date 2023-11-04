﻿using JasonMediaTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace JasonMediaTracker.Views
{
    public class MoviesPage : ContentPage
    {
        public MoviesPage()
        {
            Movie movie = new Movie("");
            FormattedString headerText = new FormattedString();
            headerText.Spans.Add(new Span { Text = "Movies", FontAttributes = FontAttributes.Bold });
            Label header = new Label { FormattedText = headerText, HorizontalTextAlignment = TextAlignment.Center };
            FormattedString uncompletedHeaderText = new FormattedString();
            uncompletedHeaderText.Spans.Add(new Span { Text = "Unwatched", FontAttributes = FontAttributes.Bold });
            Label uncompletedHeader = new Label { FormattedText = uncompletedHeaderText };
            ListView uncompletedList = new ListView { ItemsSource = movie.uncompleted };
            if (movie.uncompleted == null)
            {
                uncompletedList.ItemsSource = new List<string>() { "Empty" };
            }
            FormattedString unreleasedHeaderText = new FormattedString();
            unreleasedHeaderText.Spans.Add(new Span { Text = "Coming Soon", FontAttributes = FontAttributes.Bold });
            Label unreleasedHeader = new Label { FormattedText = unreleasedHeaderText };
            ListView unreleasedList = new ListView { ItemsSource = movie.unreleased };
            if (movie.completed == null)
            {
                unreleasedList.ItemsSource = new List<string>() { "Empty" };
            }
            FormattedString completedHeaderText = new FormattedString();
            completedHeaderText.Spans.Add(new Span { Text = "Previously Watched", FontAttributes = FontAttributes.Bold });
            Label completedHeader = new Label { FormattedText = completedHeaderText };
            ListView completedList = new ListView { ItemsSource = movie.completed };
            if (movie.completed == null)
            {
                completedList.ItemsSource = new List<string>() { "Empty" };
            }
            Button addButton = new Button { Text = "+ Add New" };
            addButton.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new NavigationPage(new AddPage()));
            };
            Content = new StackLayout
            {
                Children = {
                    header,
                    uncompletedHeader,
                    uncompletedList,
                    unreleasedHeader,
                    unreleasedList,
                    completedHeader,
                    completedList,
                    addButton
                }
            };
        }
    }
}