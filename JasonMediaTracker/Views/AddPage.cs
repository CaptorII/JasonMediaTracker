using JasonMediaTracker.Models;

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
            if (mediaType.GetType() == typeof(Book))
            {
                headerText.Spans.Add(new Span { Text = "Add new Book", FontAttributes = FontAttributes.Bold });
                label2Text.Spans.Add(new Span { Text = "Author:", FontAttributes = FontAttributes.Bold });
            }
            else if (mediaType.GetType() == typeof(Movie))
            {
                headerText.Spans.Add(new Span { Text = "Add new Movie", FontAttributes = FontAttributes.Bold });
                label2Text.Spans.Add(new Span { Text = "Release Year:", FontAttributes = FontAttributes.Bold });
            }
            else if (mediaType.GetType() == typeof(TVShow))
            {
                headerText.Spans.Add(new Span { Text = "Add new TV Show", FontAttributes = FontAttributes.Bold });
                label2Text.Spans.Add(new Span { Text = "Initial Release Year:", FontAttributes = FontAttributes.Bold });
                yearCompletedText.Spans.Add(new Span { Text = "Year Completed:", FontAttributes = FontAttributes.Bold });
            }
            titleText.Spans.Add(new Span { Text = "Title:", FontAttributes = FontAttributes.Bold });
            releaseText.Spans.Add(new Span { Text = "Release Date:", FontAttributes = FontAttributes.Bold });
            Label header = new Label { FormattedText = headerText, HorizontalTextAlignment = TextAlignment.Center };
            Label titleLabel = new Label { FormattedText = titleText };
            Entry titleField = new Entry();
            Label label2 = new Label { FormattedText = label2Text };
            Entry label2Field = new Entry();
            Label releaseLabel = new Label { FormattedText = releaseText };
            Entry releaseField = new Entry();
            Label yearCompletedLabel = new Label { FormattedText = yearCompletedText };
            Entry yearCompletedEntry = new Entry();
            Button submitButton = new Button { Text = "Add" };
            Button cancelButton = new Button { Text = "Cancel" };
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
                    yearCompletedEntry,
                    releaseLabel,
                    releaseField,
                    new StackLayout { Orientation = StackOrientation.Horizontal, Children = { submitButton, cancelButton }}
                }
                };
            }
        }
    }
}