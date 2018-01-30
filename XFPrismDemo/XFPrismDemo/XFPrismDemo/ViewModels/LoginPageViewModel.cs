using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace XFPrismDemo.ViewModels
{
	public class LoginPageViewModel : BindableBase
	{
        private readonly INavigationService _navigationService;
        private string _username;
        private string _password;
        private bool _canLogin;
        private bool _isPasswordValid;

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string Username
        {
            get { return _username; }
            set
            {
                SetProperty(ref _username, value);
                CanLogin = !string.IsNullOrEmpty(Username) && IsPasswordValid;
            }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public bool CanLogin
        {
            get { return _canLogin; }
            set { SetProperty(ref _canLogin, value); }
        }

        public bool IsPasswordValid
        {
            get {return _isPasswordValid; }
            set
            {
                SetProperty(ref _isPasswordValid, value);
                CanLogin = !string.IsNullOrEmpty(Username) && IsPasswordValid;
            }
        }

        public DelegateCommand LoginCommand => new DelegateCommand(Login).ObservesCanExecute(() => CanLogin);        

        private async void Login()
        {
            await _navigationService.NavigateAsync("NavigationMenuPage/NavigationPage/MainPage");
        }
    }
}
