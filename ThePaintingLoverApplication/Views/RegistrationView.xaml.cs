using System.Windows.Controls;
using ThePaintingLoverApplication.Services;
using ThePaintingLoverApplication.Stores;
using ThePaintingLoverApplication.ViewModels;

namespace ThePaintingLoverApplication.Views
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : UserControl
    {
        public RegistrationView()
        {
            InitializeComponent();
            //this.DataContext = new RegistrationViewModel(new UserDataService(), new NavigationStore());
        }
    }
}
