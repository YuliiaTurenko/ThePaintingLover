using System.Windows;
using System.Windows.Input;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.Services;

namespace ThePaintingLoverApplication.ViewModels
{
    public class AddArtistViewModel : ViewModelBase
    {

        private string _artistName;
        private string _artistCountry;
        private string _artistYearsOfLife;
        private string _artistBiography;
        private Window _window;
        private readonly DataService _dataService;

        public AddArtistViewModel(Window window)
        {
            _window = window;
            _dataService = new DataService();
            ArtistYearsOfLife = "(born  - died )";
            AddCommand = new RelayCommand(AddArtist);
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

        public ICommand AddCommand { get; set; }

        private void AddArtist(object parameter)
        {
            if (!string.IsNullOrEmpty(ArtistName) && !string.IsNullOrEmpty(ArtistCountry) && 
                !string.IsNullOrEmpty(ArtistYearsOfLife) && !string.IsNullOrEmpty(ArtistBiography))
            {
                Artist artist = new Artist
                {
                    Name = ArtistName,
                    Country = ArtistCountry,
                    YearsOfLife = ArtistYearsOfLife,
                    Biography = ArtistBiography
                };
                _dataService.AddArtist(artist);
                _window.DialogResult = true;
                _window.Close();
            }
        }
    }
}
