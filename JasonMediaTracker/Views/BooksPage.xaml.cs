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
        Book book = new Book("");
        ObservableCollection<Book> uncompletedBooks, unreleasedBooks, completedBooks;
        public BooksPage()
        {
            InitializeComponent();
            uncompletedBooks = new ObservableCollection<Book>();
            unreleasedBooks = new ObservableCollection<Book>();
            completedBooks = new ObservableCollection<Book>();
            Database.InitialiseDatabase();
            InitialiseBooks();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshBooks();
        }

        public async void InitialiseBooks()
        {
            while (!Database.IsInitialized)
            {
                await Task.Delay(100); // Delay and check again until the database is initialized
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
                    return;
                }
                if (book.isCompleted)
                {
                    completedBooks.Add(book);
                    return;
                }
                uncompletedBooks.Add(book);
            }
        }

        private async void AddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AddPage(book)));
        }
    }
}