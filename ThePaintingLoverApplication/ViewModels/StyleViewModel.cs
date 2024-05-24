using System.Windows.Input;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.Stores;

namespace ThePaintingLoverApplication.ViewModels
{
    public class StyleViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Style _style;
        private readonly User _user;

        public StyleViewModel(NavigationStore navigationStore, Style style, User user)
        {
            _navigationStore = navigationStore;
            _style = style;
            _user = user;
            OpenMainMenuCommand = new RelayCommand(ExecuteMainMenu);
        }

        public string StyleName => _style.Name;
        public string YearsOfExistence => _style.YearsOfExistence;
        public string Description => _style.Description;

        public ICommand OpenMainMenuCommand { get; }

        private void ExecuteMainMenu(object parameter)
        {
            _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, _user);
        }
    }
}
