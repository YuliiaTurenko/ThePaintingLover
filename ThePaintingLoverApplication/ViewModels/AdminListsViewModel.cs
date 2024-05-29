using System.Windows.Data;
using System.Windows.Input;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Commands;
using ThePaintingLoverApplication.Views;

namespace ThePaintingLoverApplication.ViewModels
{
    public class AdminListsViewModel : ViewModelBase
    {
        private readonly DataService _dataService;

        public AdminListsViewModel()
        {
            _dataService = new DataService();
            AddArtistCommand = new RelayCommand(AddArtist);
            DeleteArtistCommand = new RelayCommand(DeleteArtist);
            EditArtistCommand = new RelayCommand(EditArtist);
            AddStyleCommand = new RelayCommand(AddStyle);
            DeleteStyleCommand = new RelayCommand(DeleteStyle);
            EditStyleCommand = new RelayCommand(EditStyle);
        }

        public List<Artist> Artists => _dataService.GetArtists();
        public List<Models.Style> Styles => _dataService.GetStyles();

        public ICommand AddArtistCommand { get; }
        public ICommand DeleteArtistCommand { get; }
        public ICommand EditArtistCommand { get; }

        public ICommand AddStyleCommand { get; }
        public ICommand DeleteStyleCommand { get; }
        public ICommand EditStyleCommand { get; }

        private void AddArtist(object parameter)
        {
            var editWindow = new AddArtistWindow();
            if (editWindow.ShowDialog() == true)
            {
                OnPropertyChanged(nameof(Artists));
                CollectionViewSource.GetDefaultView(Artists).Refresh();
            }
        }

        private void DeleteArtist(object parameter)
        {
            if (parameter is Artist artist)
            {
                var confirmationDialog = new ConfirmationDialogWindow("Are you sure you want to delete data of this artist?");
                confirmationDialog.ShowDialog();
                if (confirmationDialog.IsConfirmed)
                {
                    _dataService.RemoveArtistData(artist);
                    OnPropertyChanged(nameof(Artists));
                    CollectionViewSource.GetDefaultView(Artists).Refresh();
                }
            }
        }

        private void EditArtist(object parameter)
        {
            if (parameter is Artist artist)
            {
                var editWindow = new EditArtistWindow(artist);
                if (editWindow.ShowDialog() == true)
                {
                    OnPropertyChanged(nameof(Artists));
                    CollectionViewSource.GetDefaultView(Artists).Refresh();
                }
            }
        }

        private void AddStyle(object parameter)
        {
            var editWindow = new AddStyleWindow();
            if (editWindow.ShowDialog() == true)
            {
                OnPropertyChanged(nameof(Styles));
                CollectionViewSource.GetDefaultView(Styles).Refresh();
            }
        }

        private void DeleteStyle(object parameter)
        {
            if (parameter is Style style)
            {
                var confirmationDialog = new ConfirmationDialogWindow("Are you sure you want to delete data of this style?");
                confirmationDialog.ShowDialog();
                if (confirmationDialog.IsConfirmed)
                {
                    _dataService.RemoveStyleData(style);
                    OnPropertyChanged(nameof(Styles));
                    CollectionViewSource.GetDefaultView(Styles).Refresh();
                }
            }
        }

        private void EditStyle(object parameter)
        {
            if (parameter is Style style)
            {
                var editWindow = new EditStyleWindow(style);
                if (editWindow.ShowDialog() == true)
                {
                    OnPropertyChanged(nameof(Styles));
                    CollectionViewSource.GetDefaultView(Styles).Refresh();
                }
            }
        }
    }
}
