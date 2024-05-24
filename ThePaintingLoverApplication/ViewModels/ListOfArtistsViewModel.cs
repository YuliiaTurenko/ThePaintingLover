using System.Windows.Input;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Stores;

namespace ThePaintingLoverApplication.ViewModels
{
    public class ListOfArtistsViewModel : ViewModelBase
    {
        private string _selectedArtist;
        private readonly NavigationStore _navigationStore;
        private readonly User _user;
        private readonly DataService _dataService;

        public ListOfArtistsViewModel(NavigationStore navigationStore, User currentUser)
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

        public List<string> ListOfArtists => ShowListOfArtists();

        public string SelectedArtist
        {
            get { return _selectedArtist; }
            set
            {
                _selectedArtist = value;
                OnPropertyChanged(nameof(SelectedArtist));
                OpenDetails();
            }
        }

        private List<string> ShowListOfArtists()
        {
            var artists = _dataService.GetArtists();
            var results = new List<string>();
            foreach (var artist in artists)
            {
                results.Add(artist.Name);
            }
            return results;
        }

        private void OpenDetails()
        {
            if (!string.IsNullOrEmpty(_selectedArtist))
            {
                var artist = _dataService.GetArtists().FirstOrDefault(a => a.Name == _selectedArtist);
                if (artist != null)
                {
                    _navigationStore.CurrentViewModel = new ArtistViewModel(_navigationStore, artist, _user);
                }
            }
        }
    }
}
