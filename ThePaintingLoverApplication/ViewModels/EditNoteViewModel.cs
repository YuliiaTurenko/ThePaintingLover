using System.Windows;
using System.Windows.Input;
using ThePaintingLoverApplication.Models;

namespace ThePaintingLoverApplication.ViewModels
{
    public class EditNoteViewModel : ViewModelBase
    {
        private string _noteTitle;
        private string _noteContent;
        private Note _note;
        private readonly User _user;
        private Window _window;

        public EditNoteViewModel(Window window, Note note, User user)
        {
            _user = user;
            _note = note;
            _window = window;
            SaveCommand = new RelayCommand(SaveNote);
        }

        public string Title
        {
            get { return _noteTitle; }
            set
            {
                _noteTitle = value;
                OnPropertyChanged(nameof(Title));
                ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        public string Content
        {
            get { return _noteContent; }
            set
            {
                _noteContent = value;
                OnPropertyChanged(nameof(Content));
                ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand SaveCommand { get; set; }

        private void SaveNote(object parameter)
        {
            if (!string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Content))
            {
                int index = _user.Notes.IndexOf(_note);
                _user.Notes[index] = new Note(Title, Content);
                _window.DialogResult = true;
                _window.Close();
            }
        }
    }
}
