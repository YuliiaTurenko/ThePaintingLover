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

        public LoginViewModel(NavigationStore navigationStore)
        {
            _userData = new UserDataService();
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
            if (PasswordToLogin.Length < 4)
            {
                MessageBox.Show("Password can't be less than 4 symbols and more than 30 symbols. Don't use spaces.");
                return;
            }
            if (IsValidEmail(EmailToLogin) == false)
            {
                MessageBox.Show("Email must look like this: user1111@example.com");
                return;
            }
            if (EmailToLogin.Length < 6)
            {
                MessageBox.Show("Email must have at least 6 symbols and maximum 30 symbols. Don't use spaces.");
                return;
            }
            var users = _userData.GetAllUsers();
            var user = users.FirstOrDefault(u => u.Email == EmailToLogin && u.Password == PasswordToLogin);
            if (user != null)
            {
                _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, user);
            }
            else
            {
                MessageBox.Show("Incorrect email or password.");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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