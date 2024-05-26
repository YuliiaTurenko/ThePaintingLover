using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ThePaintingLoverApplication.Views
{
    /// <summary>
    /// Interaction logic for ConfirmationDialogWindow.xaml
    /// </summary>
    public partial class ConfirmationDialogWindow : Window
    {
        public ConfirmationDialogWindow(string message)
        {
            InitializeComponent();
            MessageTextBlock.Text = message;
        }

        public bool IsConfirmed { get; private set; }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            IsConfirmed = true;
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            IsConfirmed = false;
            this.Close();
        }
    }
}
