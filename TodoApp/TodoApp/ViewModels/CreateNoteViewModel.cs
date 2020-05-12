using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public class CreateNoteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CreateNoteViewModel()
        {
            SaveNoteCommand = new Command(async () =>
            {
                var note = new Note();
                note.Text = TheNote;
                note.Date = DateTime.UtcNow;
                await App.Database.SaveNoteAsync(note);
                TheNote = string.Empty;
            });
        }

        public CreateNoteViewModel(Note notes)
        {
            TheNote = notes.Text;
            System.Diagnostics.Debug.WriteLine("DATE : " + notes.Date.ToString("dd-MM-yyyy"));

            SaveNoteCommand = new Command(async () =>
            {
                notes.Text = TheNote;
                notes.Date = DateTime.UtcNow;
                await App.Database.SaveNoteAsync(notes);
                TheNote = string.Empty;
            });
        }

        string theNote;
        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;
                var args = new PropertyChangedEventArgs(nameof(TheNote));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveNoteCommand { get; }
        public Note BindingContext { get; }
    }
}
