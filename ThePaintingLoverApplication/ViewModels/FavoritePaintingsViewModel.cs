using System.Windows.Data;
using System.Windows.Input;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Stores;
using ThePaintingLoverApplication.Commands;

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
            _user = currentUser;
            _favoritePaintings = currentUser.FavoritePaintings;
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
                if (_user.IsFavoritePainting(painting))
                {
                    _favoritePaintings.Remove(painting);
                }
                else
                {
                    _favoritePaintings.Add(painting);
                }
                _userDataService.UpdateUserData(_user);
                OnPropertyChanged(nameof(FavoritePaintings));
                CollectionViewSource.GetDefaultView(FavoritePaintings).Refresh();
            }
        }
    }
}
