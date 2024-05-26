using System.Windows.Input;
using System.Windows;
using ThePaintingLoverApplication.Services;

namespace ThePaintingLoverApplication.ViewModels
{
    public class AddStyleViewModel : ViewModelBase
    {
        private string _styleName;
        private string _styleYearsOfExistence;
        private string _styleDescription;
        private Window _window;
        private readonly DataService _dataService;

        public AddStyleViewModel(Window window)
        {
            _window = window;
            _dataService = new DataService();
            AddCommand = new RelayCommand(AddArtist);
        }

        public string StyleName
        {
            get { return _styleName; }
            set
            {
                _styleName = value;
                OnPropertyChanged(nameof(StyleName));
            }
        }

        public string StyleYearsOfExistence
        {
            get { return _styleYearsOfExistence; }
            set
            {
                _styleYearsOfExistence = value;
                OnPropertyChanged(nameof(StyleYearsOfExistence));
            }
        }
        public string StyleDescription
        {
            get { return _styleDescription; }
            set
            {
                _styleDescription = value;
                OnPropertyChanged(nameof(StyleDescription));
            }
        }

        public ICommand AddCommand { get; set; }

        private void AddArtist(object parameter)
        {
            if (!string.IsNullOrEmpty(StyleName) && !string.IsNullOrEmpty(StyleYearsOfExistence) && !string.IsNullOrEmpty(StyleDescription))
            {
                Models.Style style = new Models.Style
                {
                    Name = StyleName,
                    YearsOfExistence = StyleYearsOfExistence,
                    Description = StyleDescription
                };
                _dataService.AddStyle(style);
                _window.DialogResult = true;
                _window.Close();
            }
        }
    }
}