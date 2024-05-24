using System.Windows.Input;
using System.Windows.Media;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Stores;

namespace ThePaintingLoverApplication.ViewModels
{
    public class FavoritePaintingsViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private List<Painting> _favoritePaintings;
        private readonly User _user;
        private readonly UserDataService _userDataService;

        public FavoritePaintingsViewModel(NavigationStore navigationStore, User currentUser)
        {
            _navigationStore = navigationStore;
            _favoritePaintings = currentUser.FavoritePaintings;
            _user = currentUser;
            _userDataService = new UserDataService();
            OpenMainMenuCommand = new RelayCommand(ExecuteMainMenu);
            ToggleFavoriteCommand = new RelayCommand(ToggleFavorite);
        }

        public List<Painting> FavoritePaintings => _user.FavoritePaintings;

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
                if (_user.IsFavorite(painting))
                {
                    _favoritePaintings.Remove(painting);
                }
                else
                {
                    _favoritePaintings.Add(painting);
                }
                _userDataService.UpdateUserData(_user);
                OnPropertyChanged(nameof(FavoritePaintings));
                OnPropertyChanged(nameof(GetFavoriteButtonColor));
            }
        }

        public Brush GetFavoriteButtonColor(Painting painting)
        {
            return _user.IsFavorite(painting) ? Brushes.PaleGreen : Brushes.BlanchedAlmond;
        }
    }
}
