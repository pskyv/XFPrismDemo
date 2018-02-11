using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XFPrismDemo.Models;
using XFPrismDemo.Services;
using XFPrismDemo.Utils;

namespace XFPrismDemo.ViewModels
{
	public class NoteDetailsPageViewModel : BindableBase, INavigationAware
	{
        private Note _currentNote;
        private readonly IDatabaseService _databaseService;
        private readonly INavigationService _navigationService;

        public NoteDetailsPageViewModel(INavigationService navigationService, IDatabaseService databaseService)
        {
            _navigationService = navigationService;
            _databaseService = databaseService;
        }

        public Note CurrentNote
        {
            get { return _currentNote; }
            set { SetProperty(ref _currentNote, value); }
        }

        public DelegateCommand SaveNoteCommand => new DelegateCommand(SaveNote);                

        private async void SaveNote()
        {
            try
            {
                if (CurrentNote.Id > 0)
                {
                    await _databaseService.NoteDatabase.UpdateNoteAsync(CurrentNote);
                }
                else
                {
                    if(await _databaseService.NoteDatabase.SaveNoteAsync(CurrentNote) > 0)
                    {
                        HelperFunctions.ShowToastMessage(ToastMessageType.Success, "Note saved successfully");
                    }
                }
            }
            catch(Exception e)
            {

            }
        }        

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if(parameters != null)
            {
                CurrentNote = (Note)parameters["currentNote"];
            }
        }
    }
}
