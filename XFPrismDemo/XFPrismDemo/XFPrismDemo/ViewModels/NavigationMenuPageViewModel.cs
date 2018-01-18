using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFPrismDemo.Models;
using XFPrismDemo.Utils;

namespace XFPrismDemo.ViewModels
{
	public class NavigationMenuPageViewModel : BindableBase
	{
        private readonly INavigationService _navigationService;
        private NavigationMenuItem _selectedNavItem;

        public NavigationMenuPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            InitNavItems();
        }

        public NavigationMenuItem SelectedNaviItem
        {
            get { return _selectedNavItem; }
            set { SetProperty(ref _selectedNavItem, value); }
        }

        public ObservableCollection<NavigationMenuItem> NavItems { get; set; }

        public DelegateCommand NavigateCommand => new DelegateCommand(Navigate);

        private async void Navigate()
        {
            await _navigationService.NavigateAsync("NavigationPage/" + SelectedNaviItem.Page);
        }

        private void InitNavItems()
        {
            NavItems = new ObservableCollection<NavigationMenuItem>()
            {
                new NavigationMenuItem {Caption = Constants.MainPageCaption, Page = "MainPage", IconSource = "ic_home.png"},
                new NavigationMenuItem {Caption = Constants.SettingsPageCaption, Page = "SettingsPage", IconSource = "ic_settings.png"},
            };
        }
    }
}
