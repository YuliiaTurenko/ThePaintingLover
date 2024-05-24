using System.Windows;
using System.Windows.Input;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Stores;

namespace ThePaintingLoverApplication.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _email;
        private string _password;
        private readonly UserDataService _userData;
        private readonly NavigationStore _navigationStore;

        public LoginViewModel(UserDataService userData, NavigationStore navigationStore)
        {
            _userData = userData;
            _navigationStore = navigationStore;
            SubmitCommand = new RelayCommand(ExecuteSubmit, CanExecuteSubmit);
            CancelCommand = new RelayCommand(ExecuteCancel);
        }

        public string EmailToLogin
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(EmailToLogin));
                ((RelayCommand)SubmitCommand).RaiseCanExecuteChanged();
            }
        }

        public string PasswordToLogin
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(PasswordToLogin));
                ((RelayCommand)SubmitCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private void ExecuteSubmit(object parameter)
        {
            var users = _userData.GetAllUsers();
            var user = users.FirstOrDefault(u => u.Email == EmailToLogin && u.Password == PasswordToLogin);
            if (user != null)
            {
                MessageBox.Show("Login is successful.");
                _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, user);
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }
        }

        private bool CanExecuteSubmit(object parameter)
        {
            return !string.IsNullOrWhiteSpace(EmailToLogin) &&
                   !string.IsNullOrWhiteSpace(PasswordToLogin);
        }

        private void ExecuteCancel(object parameter)
        {
            _navigationStore.CurrentViewModel = new EntryViewModel(_navigationStore);
        }
    }
}
