using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using TodoApp.Models;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Note> NoteList { get; set; }

        public MainViewModel(MainPage activity)
        {
            GetDataNote = new Command(async () =>
            {
                NoteList = new ObservableCollection<Note>();

                var iList = await App.Database.GetNotesAsync();

                foreach (Note i in iList)
                {
                    NoteList.Add(i);
                    activity.listView.ItemsSource = NoteList;
                }

            });

            RemoveNote = new Command<Note>(async (Notes) =>
            {
                await App.Database.DeleteNoteAsync(Notes);
                NoteList.Remove(Notes);
                System.Diagnostics.Debug.WriteLine("Data Remove : " + Notes.Text);
            });
        }

        public Command GetDataNote { get; }

        public Command<Note> RemoveNote { get; }
        
    }
}
