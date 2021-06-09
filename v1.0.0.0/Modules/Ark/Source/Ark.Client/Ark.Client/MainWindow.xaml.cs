using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Ark.Client
{
    public partial class MainWindow : Window
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            this.dockPanelMain.Children.Add(new UserControlHome());
        }

        #endregion Constructors

        #region Methods

        private void OnWindowStateChanged(Object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.buttonMaximize.Visibility = Visibility.Collapsed;
                this.buttonRestore.Visibility = Visibility.Visible;
            }
            else
            {
                this.buttonMaximize.Visibility = Visibility.Visible;
                this.buttonRestore.Visibility = Visibility.Collapsed;
            }
        }

        private void OnMinimizeButtonClick(Object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void OnMaximizeRestoreButtonClick(Object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void OnCloseButtonClick(Object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
