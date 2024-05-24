using System.Windows.Input;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Stores;

namespace ThePaintingLoverApplication.ViewModels
{
    public class ListOfStylesViewModel : ViewModelBase
    {
        private string _selectedStyle;
        private readonly NavigationStore _navigationStore;
        private readonly User _user;
        private readonly DataService _dataService;

        public ListOfStylesViewModel(NavigationStore navigationStore, User currentUser)
        {
            _navigationStore = navigationStore;
            _user = currentUser;
            _dataService = new DataService();
            OpenMainMenuCommand = new RelayCommand(ExecuteMainMenu);
        }

        public ICommand OpenMainMenuCommand { get; }

        private void ExecuteMainMenu(object parameter)
        {
            _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, _user);
        }

        public List<string> ListOfStyles => ShowListOfStyles();

        public string SelectedStyle
        {
            get { return _selectedStyle; }
            set
            {
                _selectedStyle = value;
                OnPropertyChanged(nameof(SelectedStyle));
                OpenDetails();
            }
        }

        private List<string> ShowListOfStyles()
        {
            var styles = _dataService.GetStyles();
            var results = new List<string>();
            foreach (var style in styles)
            {
                results.Add(style.Name);
            }
            return results;
        }

        private void OpenDetails()
        {
            if (!string.IsNullOrEmpty(_selectedStyle))
            {
                var style = _dataService.GetStyles().FirstOrDefault(a => a.Name == _selectedStyle);
                if (style != null)
                {
                    _navigationStore.CurrentViewModel = new StyleViewModel(_navigationStore, style, _user);
                }
            }
        }
    }
}
