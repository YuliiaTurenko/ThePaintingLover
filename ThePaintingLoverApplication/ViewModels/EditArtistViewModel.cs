using System.Windows;
using System.Windows.Input;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Commands;

namespace ThePaintingLoverApplication.ViewModels
{
    public class EditArtistViewModel : ViewModelBase
    {
        private string _artistName;
        private string _artistCountry;
        private string _artistYearsOfLife;
        private string _artistBiography;
        private Artist _artist;
        private Window _window;
        private readonly DataService _dataService;

        public EditArtistViewModel(Window window, Artist artist)
        {
            _artist = artist;
            ArtistName = artist.Name;
            ArtistCountry = artist.Country;
            ArtistYearsOfLife = artist.YearsOfLife;
            ArtistBiography = artist.Biography;
            _window = window;
            _dataService = new DataService();
            SaveCommand = new RelayCommand(EditArtist);
        }

        public string ArtistName
        {
            get { return _artistName; }
            set
            {
                _artistName = value;
                OnPropertyChanged(nameof(ArtistName));
            }
        }

        public string ArtistCountry
        {
            get { return _artistCountry; }
            set
            {
                _artistCountry = value;
                OnPropertyChanged(nameof(ArtistCountry));
            }
        }

        public string ArtistYearsOfLife
        {
            get { return _artistYearsOfLife; }
            set
            {
                _artistYearsOfLife = value;
                OnPropertyChanged(nameof(ArtistYearsOfLife));
            }
        }
        public string ArtistBiography
        {
            get { return _artistBiography; }
            set
            {
                _artistBiography = value;
                OnPropertyChanged(nameof(ArtistBiography));
            }
        }

        public ICommand SaveCommand { get; set; }

        private void EditArtist(object parameter)
        {
            if (!string.IsNullOrEmpty(ArtistName) && !string.IsNullOrEmpty(ArtistCountry) &&
                !string.IsNullOrEmpty(ArtistYearsOfLife) && !string.IsNullOrEmpty(ArtistBiography))
            {
                Artist editedArtist = new Artist
                {
                    Name = ArtistName,
                    Country = ArtistCountry,
                    YearsOfLife = ArtistYearsOfLife,
                    Biography = ArtistBiography
                };
                _dataService.UpdateArtistData(_artist, editedArtist);
                _window.DialogResult = true;
                _window.Close();
            }
        }
    }
}
