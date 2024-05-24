using System.Windows;
using System.Windows.Input;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Stores;

namespace ThePaintingLoverApplication.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private string _username;
        private string _email;
        private string _password;
        private readonly UserDataService _userData;
        private readonly NavigationStore _navigationStore;

        public RegistrationViewModel(UserDataService userData, NavigationStore navigationStore)
        {
            _userData = userData;
            _navigationStore = navigationStore;
            SubmitCommand = new RelayCommand(ExecuteSubmit, CanExecuteSubmit);
            CancelCommand = new RelayCommand(ExecuteCancel);
        }

        public string Username 
        { 
            get { return _username; } 
            set 
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                ((RelayCommand)SubmitCommand).RaiseCanExecuteChanged();
            } 
        }

        public string EmailToSignup
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(EmailToSignup));
                ((RelayCommand)SubmitCommand).RaiseCanExecuteChanged();
            }
        }

        public string PasswordToSignup
        {
            get
            { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(PasswordToSignup));
                ((RelayCommand)SubmitCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private void ExecuteSubmit(object parameter)
        {
            var users = _userData.GetAllUsers();
            if (users.Any(u => u.Email == EmailToSignup))
            {
                MessageBox.Show("A user with this email address already exists.");
                return;
            }
            var newUser = new User(Username, EmailToSignup, PasswordToSignup);
            users.Add(newUser);
            _userData.SaveUserData(newUser);
            MessageBox.Show("Registration is successful.");
            _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, newUser);
        }

        private bool CanExecuteSubmit(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) &&
                   !string.IsNullOrWhiteSpace(EmailToSignup) &&
                   !string.IsNullOrWhiteSpace(PasswordToSignup);
        }

        private void ExecuteCancel(object parameter)
        {
            _navigationStore.CurrentViewModel = new EntryViewModel(_navigationStore);
        }
    }
}
