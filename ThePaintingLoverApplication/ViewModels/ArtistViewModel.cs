using System.Windows.Input;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Commands;
using ThePaintingLoverApplication.Stores;

namespace ThePaintingLoverApplication.ViewModels
{
    public class ArtistViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Artist _artist;
        private readonly User _user;
        private readonly UserDataService _userDataService;

        public ArtistViewModel(NavigationStore navigationStore, Artist artist, User user)
        {
            _navigationStore = navigationStore;
            _artist = artist;
            _user = user;
            _userDataService = new UserDataService();
            OpenMainMenuCommand = new RelayCommand(ExecuteMainMenu);
            ToggleFavoriteCommand = new RelayCommand(ToggleFavorite);
        }

        public string ArtistName => _artist.Name;
        public string Years => _artist.YearsOfLife;
        public string Country => _artist.Country;
        public string Biography => _artist.Biography;
        public List<Painting> Paintings => _artist.Paintings;

        public ICommand OpenMainMenuCommand { get; }
        public ICommand ToggleFavoriteCommand { get; }

        private void ExecuteMainMenu(object parameter)
        {
            _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, _user);
        }

        private void ToggleFavorite(object parameter)
        {
            if (parameter is Painting painting)
            {
                if (_user.IsFavoritePainting(painting))
                {
                    _user.FavoritePaintings.Remove(painting);
                }
                else
                {
                    _user.FavoritePaintings.Add(painting);
                }
                _userDataService.UpdateUserData(_user);
                OnPropertyChanged(nameof(Paintings));
            }
        }
    }
}
