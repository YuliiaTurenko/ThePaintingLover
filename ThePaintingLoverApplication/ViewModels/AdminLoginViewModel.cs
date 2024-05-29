using System.Windows.Input;
using System.Windows;
using ThePaintingLoverApplication.Stores;
using ThePaintingLoverApplication.Commands;

namespace ThePaintingLoverApplication.ViewModels
{
    public class AdminLoginViewModel : ViewModelBase
    {
        private string _password;
        private readonly NavigationStore _navigationStore;

        public AdminLoginViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            SubmitCommand = new RelayCommand(ExecuteSubmit, CanExecuteSubmit);
            CancelCommand = new RelayCommand(ExecuteCancel);
        }

        public string AdminPassword
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(AdminPassword));
                ((RelayCommand)SubmitCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private void ExecuteSubmit(object parameter)
        {
            if (AdminPassword.Length < 4)
            {
                MessageBox.Show("Password can't be less than 4 symbols and more than 30 symbols. Don't use spaces.");
                return;
            }
            if (AdminPassword == "admin17")
            {
                _navigationStore.CurrentViewModel = new AdminListsViewModel();
            }
            else
            {
                MessageBox.Show("Incorrect password.");
            }
        }

        private bool CanExecuteSubmit(object parameter)
        {
            return !string.IsNullOrWhiteSpace(AdminPassword);
        }

        private void ExecuteCancel(object parameter)
        {
            _navigationStore.CurrentViewModel = new EntryViewModel(_navigationStore);
        }
    }
}
