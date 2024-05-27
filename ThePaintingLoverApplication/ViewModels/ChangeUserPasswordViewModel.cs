using System.Windows.Input;
using System.Windows;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Stores;
using ThePaintingLoverApplication.Models;

namespace ThePaintingLoverApplication.ViewModels
{
    public class ChangeUserPasswordViewModel : ViewModelBase
    {
        private string _userPassword;
        private string _newPassword;
        private readonly User _user;
        private readonly UserDataService _userData;
        private readonly NavigationStore _navigationStore;

        public ChangeUserPasswordViewModel(User user, NavigationStore navigationStore)
        {
            _user = user;
            _userData = new UserDataService();
            _navigationStore = navigationStore;
            SubmitCommand = new RelayCommand(ExecuteSubmit, CanExecuteSubmit);
            CancelCommand = new RelayCommand(ExecuteCancel);
        }

        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                OnPropertyChanged(nameof(UserPassword));
                ((RelayCommand)SubmitCommand).RaiseCanExecuteChanged();
            }
        }

        public string NewUserPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                OnPropertyChanged(nameof(NewUserPassword));
                ((RelayCommand)SubmitCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private void ExecuteSubmit(object parameter)
        {
            var users = _userData.GetAllUsers();
            var user = users.FirstOrDefault(u => u.Password == UserPassword);
            if (user != null)
            {
                if (NewUserPassword.Length < 4)
                {
                    MessageBox.Show("Password can't be less than 4 symbols and more than 30 symbols. Don't use spaces.");
                    return;
                }
                if (!NewUserPassword.Any(char.IsDigit))
                {
                    MessageBox.Show("Password must have at least one number.");
                    return;
                }
                _userData.UpdateUserPassword(_user, NewUserPassword);
                _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, user);
            }
            else
            {
                MessageBox.Show("Incorrect password.");
            }
        }

        private bool CanExecuteSubmit(object parameter)
        {
            return !string.IsNullOrWhiteSpace(UserPassword) &&
                   !string.IsNullOrWhiteSpace(NewUserPassword);
        }

        private void ExecuteCancel(object parameter)
        {
            _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, _user);
        }
    }
}
