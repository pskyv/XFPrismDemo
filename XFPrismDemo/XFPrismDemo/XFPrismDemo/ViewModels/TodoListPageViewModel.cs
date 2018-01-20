using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFPrismDemo.Models;
using XFPrismDemo.Services;

namespace XFPrismDemo.ViewModels
{
	public class TodoListPageViewModel : BindableBase
	{
        private readonly IDatabaseService _databaseService;
        private string _newItemDescription;

        public TodoListPageViewModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
            TodoItems = new ObservableCollection<TodoItem>();
            GetTodoItems();
        }

        public string NewItemDescription
        {
            get { return _newItemDescription; }
            set { SetProperty(ref _newItemDescription, value); }
        }

        public ObservableCollection<TodoItem> TodoItems { get; }

        public DelegateCommand CreateItemCommand => new DelegateCommand(CreateItem);

        private async void GetTodoItems()
        {
            var items = await _databaseService.TodoItemDatabase.GetItemsAsync();
            TodoItems.Clear();
            foreach(var item in items)
            {
                TodoItems.Add(item);
            }
        }

        private async void CreateItem()
        {
            if(string.IsNullOrEmpty(NewItemDescription))
            {
                return;
            }

            var item = new TodoItem { Description = NewItemDescription, IsDone = false, CreatedAt = DateTime.Now };
            try
            {
                await _databaseService.TodoItemDatabase.SaveItemAsync(item);
                TodoItems.Add(item);
                NewItemDescription = string.Empty;
            }
            catch(Exception e)
            {

            }
        }
    }
}
