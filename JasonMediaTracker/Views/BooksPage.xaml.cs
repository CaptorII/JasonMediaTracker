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
    public partial class BooksPage : ContentPage
    {
        Book book = new Book();
        ObservableCollection<Book> uncompletedBooks, unreleasedBooks, completedBooks;
        public BooksPage()
        {
            InitializeComponent();
            uncompletedBooks = new ObservableCollection<Book>();
            unreleasedBooks = new ObservableCollection<Book>();
            completedBooks = new ObservableCollection<Book>();
            InitialiseBooks();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Database.IsInitialized) 
                RefreshBooks();
        }

        public async void InitialiseBooks()
        {
            Database.InitialiseDatabase();
            while (!Database.IsInitialized)
            {
                await Task.Delay(100); // delay and check again until the database is initialized
            }
            RefreshBooks();
            UncompletedList.ItemsSource = uncompletedBooks;
            UnreleasedList.ItemsSource = unreleasedBooks;
            CompletedList.ItemsSource = completedBooks;
        }

        private void RefreshBooks()
        {
            uncompletedBooks.Clear();
            unreleasedBooks.Clear();
            completedBooks.Clear();
            List<Book> allBooks = Database.db.Table<Book>().ToListAsync().Result;
            foreach (Book book in allBooks)
            {
                if (book.releaseDate > DateTime.Today) // if release date is in the future
                {
                    unreleasedBooks.Add(book);
                }
                else if (book.isCompleted)
                {
                    completedBooks.Add(book);
                }
                else
                {
                    uncompletedBooks.Add(book);
                }
            }
        }

        private async void MarkCompleted(object sender, ToggledEventArgs e)
        {
            if (sender is Switch toggleSwitch && toggleSwitch.BindingContext is Book book)
            {
                if (!toggleSwitch.IsToggled) return; // prevents method running every time lists are refreshed

                book.isCompleted = true;
                Database.UpdateTable(book);
                while (!Database.OperationCompleted)
                {
                    await Task.Delay(100); // delay and check again until the task is completed
                }
                RefreshBooks();
            }
        }

        private async void MarkIncomplete(object sender, ToggledEventArgs e)
        {
            if (sender is Switch toggleSwitch && toggleSwitch.BindingContext is Book book)
            {
                if (toggleSwitch.IsToggled) return; // prevents method running every time lists are refreshed

                book.isCompleted = false;
                Database.UpdateTable(book);
                while (!Database.OperationCompleted)
                {
                    await Task.Delay(100); // delay and check again until the task is completed
                }
                RefreshBooks();
            }
        }

        private async void AddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AddPage(book)));
        }
    }
}