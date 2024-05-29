using System.Windows.Input;
using System.Windows;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Commands;

namespace ThePaintingLoverApplication.ViewModels
{
    public class EditStyleViewModel : ViewModelBase
    {
        private string _styleName;
        private string _styleYearsOfExistence;
        private string _styleDescription;
        private Models.Style _style;
        private Window _window;
        private readonly DataService _dataService;

        public EditStyleViewModel(Window window, Models.Style style)
        {
            _style = style;
            StyleName = style.Name;
            StyleYearsOfExistence = style.YearsOfExistence;
            StyleDescription = style.Description;
            _window = window;
            _dataService = new DataService();
            SaveCommand = new RelayCommand(EditArtist);
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

        public ICommand SaveCommand { get; set; }

        private void EditArtist(object parameter)
        {
            if (!string.IsNullOrEmpty(StyleName) && !string.IsNullOrEmpty(StyleYearsOfExistence) && !string.IsNullOrEmpty(StyleDescription))
            {
                Models.Style style = new Models.Style
                {
                    Name = StyleName,
                    YearsOfExistence = StyleYearsOfExistence,
                    Description = StyleDescription
                };
                _dataService.UpdateStyleData(_style, style);
                _window.DialogResult = true;
                _window.Close();
            }
        }
    }
}