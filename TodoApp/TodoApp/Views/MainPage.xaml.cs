using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.ViewModels;
using TodoApp.Views;
using Xamarin.Forms;

namespace TodoApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Note> NoteList { get; set; }
        public MainPage()
        {
            BindingContext = new MainViewModel(this);
            NoteList = new ObservableCollection<Note>();
            InitializeComponent();
        }

        async private void AddNote_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Adv());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as MainViewModel;
            
            vm.GetDataNote.Execute(NoteList);
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Note tappedNoteItem = e.Item as Note;

            var createNoteVM = new CreateNoteViewModel(tappedNoteItem);

            var createNotePage = new CreateNotePage();

            createNotePage.BindingContext = createNoteVM;

            await Navigation.PushAsync(createNotePage);

            System.Diagnostics.Debug.WriteLine("SELECTED : " + tappedNoteItem.ID);
        }

        private void RemoveNote_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var note = button.BindingContext as Note;
            var vm = BindingContext as MainViewModel;
            vm.RemoveNote.Execute(note);
        }
    }
}
