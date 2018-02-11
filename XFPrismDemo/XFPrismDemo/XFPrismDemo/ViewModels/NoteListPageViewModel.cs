using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XFPrismDemo.Models;
using XFPrismDemo.Services;
using XFPrismDemo.Utils;
using XFPrismDemo.Views;

namespace XFPrismDemo.ViewModels
{
	public class NoteListPageViewModel : BindableBase
	{
        private readonly IDatabaseService _databaseService;
        private readonly INavigationService _navigationService;
        private IEnumerable<Note> _notes;
        private Note _selectedNote;

        public NoteListPageViewModel(INavigationService navigationService, IDatabaseService databaseService)
        {
            _navigationService = navigationService;
            _databaseService = databaseService;

            NotesGrouped = new ObservableCollection<Grouping<string, Note>>();
            MessagingCenter.Subscribe<NoteListPage>(this, Constants.OnNotesAppearingMsg, (sender) => { GetNotes(); });            
        }

        public Note SelectedNote
        {
            get { return _selectedNote; }
            set { SetProperty(ref _selectedNote, value); }
        }

        public ObservableCollection<Grouping<string, Note>> NotesGrouped { get; set; }

        public DelegateCommand<string> NavigateToNoteDetailCommand => new DelegateCommand<string>(NavigateToNoteDetail);

        public DelegateCommand<Note> RemoveFromListCommand => new DelegateCommand<Note>(RemoveFromList);

        private async void NavigateToNoteDetail(string mode)
        {
            if(mode.Equals("Add"))
            {
                var note = new Note { CreatedAt = DateTime.Now };
                SelectedNote = note;
            }

            var navParams = new NavigationParameters();
            navParams.Add("currentNote", SelectedNote);
            await _navigationService.NavigateAsync("NoteDetailsPage", navParams);
        }

        private async void GetNotes()
        {
            _notes = await _databaseService.NoteDatabase.GetNotesAsync();

            var group = from note in _notes
                        orderby note.CreatedAt descending
                        group note by note.ListHeader into noteGroup
                        select new Grouping<string, Note>(noteGroup.Key, noteGroup);

            NotesGrouped.Clear();
            foreach(var item in group)
            {
                NotesGrouped.Add(item);
            }

            //MessagingCenter.Unsubscribe<NoteListPage>(this, Constants.OnNotesAppearingMsg);
        }

        private async void RemoveFromList(Note note)
        {
            try
            {
                if (await _databaseService.NoteDatabase.DeleteNoteAsync(note) > 0)
                {
                    //NotesGrouped.Remove(note);
                    GetNotes();
                }
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
        }
    }
}
