using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XFPrismDemo.Models;
using XFPrismDemo.Utils;
using XFPrismDemo.Views;

namespace XFPrismDemo.ViewModels
{
	public class NoteListPageViewModel : BindableBase
	{
        private List<Note> _notes;
        public NoteListPageViewModel()
        {
            _notes = new List<Note>();
            NotesGrouped = new ObservableCollection<Grouping<string, Note>>();
            MessagingCenter.Subscribe<NoteListPage>(this, Constants.OnNotesAppearingMsg, (sender) => { GetNotes(); });            
        }

        public ObservableCollection<Grouping<string, Note>> NotesGrouped { get; set; }

        private void GetNotes()
        {
            _notes.Add(new Note { Title = "Note 1", CreatedAt = DateTime.Now, Text = "First payment was made when I was in Athens" });
            _notes.Add(new Note { Title = "Note 2", CreatedAt = DateTime.Now });
            _notes.Add(new Note { Title = "Note 3", CreatedAt = DateTime.Now.AddMonths(-1) });
            _notes.Add(new Note { Title = "Note 4", CreatedAt = DateTime.Now.AddMonths(-1) });
            _notes.Add(new Note { Title = "Note 5", CreatedAt = DateTime.Now.AddMonths(-1) });
            _notes.Add(new Note { Title = "Note 6", CreatedAt = DateTime.Now.AddMonths(-2) });
            _notes.Add(new Note { Title = "Note 7", CreatedAt = DateTime.Now.AddMonths(-2) });
            _notes.Add(new Note { Title = "Note 8", CreatedAt = DateTime.Now.AddMonths(-2) });
            _notes.Add(new Note { Title = "Note 9", CreatedAt = DateTime.Now.AddMonths(-4) });
            _notes.Add(new Note { Title = "Note 10", CreatedAt = DateTime.Now.AddMonths(-4) });
            _notes.Add(new Note { Title = "Note 11", CreatedAt = DateTime.Now.AddMonths(-5) });
            _notes.Add(new Note { Title = "Note 12", CreatedAt = DateTime.Now.AddMonths(-5) });
            _notes.Add(new Note { Title = "Note 13", CreatedAt = DateTime.Now.AddMonths(-5) });
            _notes.Add(new Note { Title = "Note 14", CreatedAt = DateTime.Now.AddMonths(-7) });
            _notes.Add(new Note { Title = "Note 15", CreatedAt = DateTime.Now.AddMonths(-7) });
            _notes.Add(new Note { Title = "Note 16", CreatedAt = DateTime.Now.AddMonths(-7) });
            _notes.Add(new Note { Title = "Note 17", CreatedAt = DateTime.Now.AddMonths(-10) });
            _notes.Add(new Note { Title = "Note 18", CreatedAt = DateTime.Now.AddMonths(-10) });
            _notes.Add(new Note { Title = "Note 19", CreatedAt = DateTime.Now });
            _notes.Add(new Note { Title = "Note 20", CreatedAt = DateTime.Now });
            _notes.Add(new Note { Title = "Note 21", CreatedAt = DateTime.Now });
            _notes.Add(new Note { Title = "Note 22", CreatedAt = DateTime.Now, Text = "Last car service 6 months ago. 75000Km" });

            var group = from note in _notes
                        orderby note.CreatedAt descending
                        group note by note.ListHeader into noteGroup
                        select new Grouping<string, Note>(noteGroup.Key, noteGroup);

            NotesGrouped.Clear();
            foreach(var item in group)
            {
                NotesGrouped.Add(item);
            }

            MessagingCenter.Unsubscribe<NoteListPage>(this, Constants.OnNotesAppearingMsg);
        }        
	}
}
