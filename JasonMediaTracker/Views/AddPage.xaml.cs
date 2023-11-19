using JasonMediaTracker.Models;
using JasonMediaTracker.ViewModels;
using Xamarin.Forms;

namespace JasonMediaTracker.Views
{
    public partial class AddPage : ContentPage
    {
        public AddPage(Media mediaType)
        {
            AddViewModel model = new AddViewModel();
            FormattedString headerText = new FormattedString();
            FormattedString titleText = new FormattedString();
            titleText.Spans.Add(new Span { Text = "Title:", FontAttributes = FontAttributes.Bold });
            FormattedString label2Text = new FormattedString();
            FormattedString releaseText = new FormattedString();
            releaseText.Spans.Add(new Span { Text = "Release Date:", FontAttributes = FontAttributes.Bold });
            FormattedString yearCompletedText = new FormattedString();
            Entry titleField = new Entry();
            Entry label2Field = new Entry();
            Entry yearCompletedField = new Entry();
            DatePicker releaseField = new DatePicker();
            Button submitButton = new Button { Text = "Add" };
            Button cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += (sender, args) => ReturnToPrevious();
            if (mediaType.GetType() == typeof(Book))
            {
                headerText.Spans.Add(new Span { Text = "Add new Book", FontAttributes = FontAttributes.Bold, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))});
                label2Text.Spans.Add(new Span { Text = "Author:", FontAttributes = FontAttributes.Bold });
                submitButton.Clicked += (sender, args) => model.CreateMedia((Book)mediaType, titleField.Text, releaseField.Date, label2Field.Text);
            }
            else if (mediaType.GetType() == typeof(Movie))
            {
                headerText.Spans.Add(new Span { Text = "Add new Movie", FontAttributes = FontAttributes.Bold, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))});
                label2Text.Spans.Add(new Span { Text = "Release Year:", FontAttributes = FontAttributes.Bold });
                label2Field.Keyboard = Keyboard.Numeric;
                submitButton.Clicked += (sender, args) => model.CreateMedia((Movie)mediaType, titleField.Text, releaseField.Date, label2Field.Text);
            }
            else if (mediaType.GetType() == typeof(TVShow))
            {
                headerText.Spans.Add(new Span { Text = "Add new TV Show", FontAttributes = FontAttributes.Bold, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))});
                label2Text.Spans.Add(new Span { Text = "Initial Release Year:", FontAttributes = FontAttributes.Bold });
                label2Field.Keyboard = Keyboard.Numeric;
                yearCompletedText.Spans.Add(new Span { Text = "Year Completed:", FontAttributes = FontAttributes.Bold });
                yearCompletedField.Keyboard = Keyboard.Numeric;
                submitButton.Clicked += (sender, args) => model.CreateMedia((TVShow)mediaType, titleField.Text, releaseField.Date, label2Field.Text, yearCompletedField.Text);
            }
            Label header = new Label { FormattedText = headerText, HorizontalTextAlignment = TextAlignment.Center };
            Label titleLabel = new Label { FormattedText = titleText };
            Label label2 = new Label { FormattedText = label2Text };
            Label yearCompletedLabel = new Label { FormattedText = yearCompletedText };
            Label releaseLabel = new Label { FormattedText = releaseText };
            if (mediaType.GetType() == typeof(Book) | mediaType.GetType() == typeof(Movie))
            {
                Content = new StackLayout
                {
                    Padding = new Thickness(10),
                    Children = {
                    header,
                    titleLabel,
                    titleField,
                    label2,
                    label2Field,
                    releaseLabel,
                    releaseField,
                    new Grid {
                        Children = {
                            { submitButton, 0, 0 },
                            { cancelButton, 1, 0 }}} 
                    }
                };
            }
            else if (mediaType.GetType() == typeof(TVShow))
            {
                Content = new StackLayout
                {
                    Padding = new Thickness(10),
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
                    new Grid {
                        Children = {
                            { submitButton, 0, 0 },
                            { cancelButton, 1, 0 }}}
                    }
                };
            }
        }

        public async void ReturnToPrevious()
        {
            await Shell.Current.Navigation.PopAsync();
        }
    }
}