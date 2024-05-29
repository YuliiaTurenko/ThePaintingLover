using System.Windows;
using System.Windows.Input;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Stores;
using ThePaintingLoverApplication.Commands;

namespace ThePaintingLoverApplication.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        private string _searchQuery;
        private List<string> _searchResults;
        private string _selectedResult;
        private readonly DataService _dataService;
        private readonly NavigationStore _navigationStore;
        private readonly User _currentUser;

        public MainMenuViewModel(NavigationStore navigationStore, User currentUser)
        {
            _searchResults = new List<string>();
            _navigationStore = navigationStore;
            _currentUser = currentUser;
            _dataService = new DataService();
            ShowListOfArtistsCommand = new RelayCommand(ShowListOfArtists);
            ShowListOfStylesCommand = new RelayCommand(ShowListOfStyles);
            ShowFavoritePaintingsCommand = new RelayCommand(ShowFavoritePaintings);
            ShowNotesCommand = new RelayCommand(ShowNotes);
            ChangePasswordCommand = new RelayCommand(ChangePassword);
            SearchCommand = new RelayCommand(ExecuteSearch, CanExecuteSearch);
        }

        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                ((RelayCommand)SearchCommand).RaiseCanExecuteChanged();
            }
        }

        public List<string> SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                OnPropertyChanged(nameof(SearchResults));
            }
        }
        
        public string SelectedResult
        {
            get { return _selectedResult; }
            set
            {
                _selectedResult = value;
                OnPropertyChanged(nameof(SelectedResult));
                OpenDetails();
            }
        }

        public ICommand ShowListOfArtistsCommand { get; }
        public ICommand ShowListOfStylesCommand { get; }
        public ICommand ShowFavoritePaintingsCommand { get; }
        public ICommand ShowNotesCommand { get; }
        public ICommand ChangePasswordCommand {  get; }
        public ICommand SearchCommand { get; }

        private void ShowListOfArtists(object parameter)
        {
            _navigationStore.CurrentViewModel = new ListOfArtistsViewModel(_navigationStore, _currentUser);
        }

        private void ShowListOfStyles(object parameter)
        {
            _navigationStore.CurrentViewModel = new ListOfStylesViewModel(_navigationStore, _currentUser);
        }

        private void ShowFavoritePaintings(object parameter)
        {
            _navigationStore.CurrentViewModel = new FavoritePaintingsViewModel(_navigationStore, _currentUser);
        }

        private void ShowNotes(object parameter)
        {
            _navigationStore.CurrentViewModel = new NotesViewModel(_navigationStore, _currentUser);
        }

        private void ChangePassword(object parameter)
        {
            _navigationStore.CurrentViewModel = new ChangeUserPasswordViewModel(_currentUser, _navigationStore);
        }

        private bool CanExecuteSearch(object parameter)
        {
            return !string.IsNullOrWhiteSpace(SearchQuery);
        }

        private void ExecuteSearch(object parameter)
        {
            var artists = _dataService.GetArtists();
            var styles = _dataService.GetStyles();
            var results = new List<string>();
            foreach (var artist in artists)
            {
                if (artist.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    artist.Country.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    artist.YearsOfLife.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    artist.Biography.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    artist.Paintings.Any(p => p.Title.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) || 
                    p.CreationYear.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)))
                {
                    results.Add(artist.Name);
                }
            }
            foreach (var style in styles)
            {
                if (style.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                style.YearsOfExistence.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                style.Description.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(style.Name);
                }
            }
            if(results.Count == 0)
            {
                MessageBox.Show("No results were found.");
            }
            else
            {
                SearchResults = results;
            }
        }

        private void OpenDetails()
        {
            if (!string.IsNullOrEmpty(_selectedResult))
            {
                var artist = _dataService.GetArtists().FirstOrDefault(a => a.Name == _selectedResult);
                if (artist != null)
                {
                    _navigationStore.CurrentViewModel = new ArtistViewModel(_navigationStore, artist, _currentUser);
                }
                else
                {
                    var style = _dataService.GetStyles().FirstOrDefault(s => s.Name == _selectedResult);
                    if (style != null)
                    {
                        _navigationStore.CurrentViewModel = new StyleViewModel(_navigationStore, style, _currentUser);
                    }
                }
            }
        }
    }
}
