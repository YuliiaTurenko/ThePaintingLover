using System.Windows.Input;
using ThePaintingLoverApplication.Stores;
using ThePaintingLoverApplication.Commands;

namespace ThePaintingLoverApplication.ViewModels
{
    public class EntryViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public EntryViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            RegistrationCommand = new RelayCommand(ExecuteRegistrationCommand);
            LoginCommand = new RelayCommand(ExecuteLoginCommand);
            OpenForAdminCommand = new RelayCommand(ExecuteOpenForAdminCommand);
        }

        public ICommand RegistrationCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand OpenForAdminCommand { get; }

        private void ExecuteRegistrationCommand(object parameter)
        {
            _navigationStore.CurrentViewModel = new RegistrationViewModel(_navigationStore);
        }

        private void ExecuteLoginCommand(object parameter)
        {
            _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore);
        }

        private void ExecuteOpenForAdminCommand(object parameter)
        {
            _navigationStore.CurrentViewModel = new AdminLoginViewModel(_navigationStore);
        }
    }
}
