using System.Windows;
using ThePaintingLoverApplication.ViewModels;
using ThePaintingLoverApplication.Models;

namespace ThePaintingLoverApplication.Views
{
    /// <summary>
    /// Interaction logic for EditNoteWindow.xaml
    /// </summary>
    public partial class EditNoteWindow : Window
    {
        public EditNoteWindow(Note note, User user)
        {
            InitializeComponent();
            DataContext = new EditNoteViewModel(this, note, user);
        }
    }
}
