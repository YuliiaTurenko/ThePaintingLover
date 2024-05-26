using System.Windows;
using ThePaintingLoverApplication.ViewModels;

namespace ThePaintingLoverApplication.Views
{
    /// <summary>
    /// Interaction logic for EditStyleWindow.xaml
    /// </summary>
    public partial class EditStyleWindow : Window
    {
        public EditStyleWindow(Models.Style style)
        {
            InitializeComponent();
            DataContext = new EditStyleViewModel(this, style);
        }
    }
}
