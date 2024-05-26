using System.Windows;
using ThePaintingLoverApplication.ViewModels;

namespace ThePaintingLoverApplication.Views
{
    /// <summary>
    /// Interaction logic for AddStyleWindow.xaml
    /// </summary>
    public partial class AddStyleWindow : Window
    {
        public AddStyleWindow()
        {
            InitializeComponent();
            DataContext = new AddStyleViewModel(this);
        }
    }
}
