using System.Windows.Input;
using ThePaintingLoverApplication.Stores;
using ThePaintingLoverApplication.ViewModels;

namespace ThePaintingLoverApplication.Commands
{
    public class NavigateCommand<TViewModel> : ICommand where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
