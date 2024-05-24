using System.Windows.Input;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Stores;

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
        }

        public ICommand RegistrationCommand { get; }
        public ICommand LoginCommand { get; }

        private void ExecuteRegistrationCommand(object parameter)
        {
            _navigationStore.CurrentViewModel = new RegistrationViewModel(new UserDataService(), _navigationStore);
        }

        private void ExecuteLoginCommand(object parameter)
        {
            _navigationStore.CurrentViewModel = new LoginViewModel(new UserDataService(), _navigationStore);
        }
    }
}
