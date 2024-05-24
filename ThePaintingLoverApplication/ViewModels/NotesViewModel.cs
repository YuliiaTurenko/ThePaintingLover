using System.Diagnostics.Metrics;
using System.Windows.Input;
using System.Xml.Linq;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Stores;

namespace ThePaintingLoverApplication.ViewModels
{
    public class NotesViewModel : ViewModelBase
    {
        private string _noteTitle;
        private string _noteContent;
        private Note _selectedNote;
        private readonly NavigationStore _navigationStore;
        private readonly User _user;
        private readonly UserDataService _userDataService;

        public NotesViewModel(NavigationStore navigationStore, User currentUser)
        {
            _navigationStore = navigationStore;
            _user = currentUser;
            _userDataService = new UserDataService();
            OpenMainMenuCommand = new RelayCommand(ExecuteMainMenu);
            AddNoteCommand = new RelayCommand(AddNote);
            DeleteCommand = new RelayCommand(DeleteNote);
            EditCommand = new RelayCommand(EditNote);
        }

        public List<Note> Notes => _user.Notes;

        public string NoteTitle
        {
            get { return _noteTitle; }
            set
            {
                _noteTitle = value;
                OnPropertyChanged(nameof(NoteTitle));
            }
        }

        public string NoteContent
        {
            get { return _noteContent; }
            set
            {
                _noteContent = value;
                OnPropertyChanged(nameof(NoteContent));
            }
        }

        public Note SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                _selectedNote = value;
                OnPropertyChanged(nameof(SelectedNote));
                UpdateTextBoxes();
            }
        }

        public ICommand OpenMainMenuCommand { get; }
        public ICommand AddNoteCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }

        private void ExecuteMainMenu(object parameter)
        {
            _navigationStore.CurrentViewModel = new MainMenuViewModel(_navigationStore, _user);
        }

        private void AddNote(object parameter)
        {
            if (!string.IsNullOrEmpty(NoteTitle) && !string.IsNullOrEmpty(NoteContent))
            {
                _user.Notes.Add(new Note(NoteTitle, NoteContent));
                _userDataService.UpdateUserData(_user);
                NoteTitle = string.Empty;
                NoteContent = string.Empty;
            }
        }

        // finish method for delete command
        private void DeleteNote(object parameter)
        {
            _user.Notes.Remove(SelectedNote);
            _userDataService.UpdateUserData(_user);
            OnPropertyChanged(nameof(Notes));
        }
        // finish method for edit command
        private void EditNote(object parameter)
        {
            if (parameter is Note note)
            {
                SelectedNote = note;
            }
        }
        private void UpdateTextBoxes()
        {
            if (SelectedNote != null)
            {
                NoteTitle = SelectedNote.Title;
                NoteContent = SelectedNote.Content;
            }
        }
    }
}
