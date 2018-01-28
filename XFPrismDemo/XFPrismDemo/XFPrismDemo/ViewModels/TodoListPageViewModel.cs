using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFPrismDemo.Models;
using XFPrismDemo.Services;
using XFPrismDemo.Utils;

namespace XFPrismDemo.ViewModels
{
	public class TodoListPageViewModel : BindableBase
	{
        private readonly IDatabaseService _databaseService;
        private string _newItemDescription;
        private bool _isRefreshing;

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

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        public ObservableCollection<TodoItem> TodoItems { get; }

        public DelegateCommand CreateItemCommand => new DelegateCommand(CreateItem);

        public DelegateCommand<TodoItem> RemoveFromListCommand => new DelegateCommand<TodoItem>(RemoveItem);

        public DelegateCommand RefreshCommand => new DelegateCommand(RefreshItemsList);

        public DelegateCommand<TodoItem> UpdateItemCommand => new DelegateCommand<TodoItem>(UpdateItem);

        private async void UpdateItem(TodoItem item)
        {
            try
            {
                await _databaseService.TodoItemDatabase.UpdateItemAsync(item);
            }
            catch(Exception e) { }
        }

        private void RefreshItemsList()
        {
            GetTodoItems();
            IsRefreshing = false;
        }

        private async void RemoveItem(TodoItem item)
        {
            try
            {
                if (await _databaseService.TodoItemDatabase.DeleteItemAsync(item) > 0)
                {
                    TodoItems.Remove(item);
                }
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
        }

        private async void GetTodoItems()
        {
            var items = await _databaseService.TodoItemDatabase.GetItemsNotDoneAsync();
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
                if (await _databaseService.TodoItemDatabase.SaveItemAsync(item) > 0)
                {
                    TodoItems.Add(item);
                    NewItemDescription = string.Empty;
                    HelperFunctions.ShowToastMessage(ToastMessageType.Success, "Item saved successfully");
                }
            }
            catch(Exception e)
            {

            }
        }
    }
}
