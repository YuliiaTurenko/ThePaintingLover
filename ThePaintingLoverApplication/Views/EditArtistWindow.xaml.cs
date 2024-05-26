using System.Windows;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.ViewModels;

namespace ThePaintingLoverApplication.Views
{
    /// <summary>
    /// Interaction logic for EditArtistWindow.xaml
    /// </summary>
    public partial class EditArtistWindow : Window
    {
        public EditArtistWindow(Artist artist)
        {
            InitializeComponent();
            DataContext = new EditArtistViewModel(this, artist);
        }
    }
}
