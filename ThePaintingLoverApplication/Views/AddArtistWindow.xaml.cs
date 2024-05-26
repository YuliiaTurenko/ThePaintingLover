using System.Windows;
using ThePaintingLoverApplication.Models;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.ViewModels;

namespace ThePaintingLoverApplication.Views
{
    /// <summary>
    /// Interaction logic for AddArtistWindow.xaml
    /// </summary>
    public partial class AddArtistWindow : Window
    {
        public AddArtistWindow()
        {
            InitializeComponent();
            DataContext = new AddArtistViewModel(this);
        }
    }
}
