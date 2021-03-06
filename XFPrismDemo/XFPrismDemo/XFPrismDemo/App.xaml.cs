﻿using Prism;
using Prism.Ioc;
using XFPrismDemo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using XFPrismDemo.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFPrismDemo
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("LoginPage");
            //await NavigationService.NavigateAsync("NavigationMenuPage/NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<NavigationMenuPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<TodoListPage>();
            containerRegistry.RegisterForNavigation<LoginPage>();
            containerRegistry.RegisterForNavigation<NoteListPage>();
            containerRegistry.RegisterForNavigation<NoteDetailsPage>();

            containerRegistry.RegisterSingleton(typeof(IDatabaseService), typeof(DatabaseService));            
        }
    }
}
