using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace JasonMediaTracker.Views
{
    public class AddPage : ContentPage
    {
        public AddPage()
        {
            FormattedString headerText = new FormattedString();
            headerText.Spans.Add(new Span { Text = "Add", FontAttributes = FontAttributes.Bold });
            Label header = new Label { FormattedText = headerText, HorizontalTextAlignment = TextAlignment.Center };
            Content = new StackLayout
            {
                Children = {
                    header
                }
            };
        }
    }
}