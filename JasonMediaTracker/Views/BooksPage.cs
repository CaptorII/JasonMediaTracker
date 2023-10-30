using JasonMediaTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace JasonMediaTracker.Views
{
    public class BooksPage : ContentPage
    {
        public BooksPage()
        {
            Book book = new Book("");
            ListView incompleteList = new ListView { ItemsSource = book.uncompleted };
            ListView unreleasedList = new ListView { ItemsSource = book.unreleased };
            ListView completedList = new ListView { ItemsSource = book.completed };
            Button addButton = new Button { Text = "+ Add New" };
            Content = new StackLayout
            {
                Children = {
                    incompleteList,
                    unreleasedList,
                    completedList,                    
                    addButton
                }
            };
        }
    }
}