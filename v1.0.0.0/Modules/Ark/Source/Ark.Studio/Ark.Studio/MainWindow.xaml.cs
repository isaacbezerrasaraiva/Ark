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

using Lazy;

using Ark.Lib;
using Ark.Studio.UserControls;

namespace Ark.Studio
{
    public partial class MainWindow : Window
    {
        #region Variables

        private UserControlSolution userControlSolution;
        private UserControlFeature userControlFeature;

        #endregion Variables

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void OnMenuItemSolutionClick(Object sender, RoutedEventArgs e)
        {
            if (this.userControlSolution == null)
                this.userControlSolution = new UserControlSolution();

            if (this.panelContent.Children.Count > 0)
            {
                if (MessageBox.Show(LibGlobalization.GetTranslation(Properties.Resources.StdMessageCancelCurrentEdition), LibGlobalization.GetTranslation(Properties.Resources.StdCaptionCancel), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    this.userControlSolution.Clear();
                    this.panelContent.Children.RemoveAt(0);
                    this.panelContent.Children.Add(this.userControlSolution);
                }
            }
            else
            {
                this.panelContent.Children.Add(this.userControlSolution);
            }
        }

        private void OnMenuItemFeatureClick(Object sender, RoutedEventArgs e)
        {
            if (this.userControlFeature == null)
                this.userControlFeature = new UserControlFeature();

            if (this.panelContent.Children.Count > 0)
            {
                if (MessageBox.Show(LibGlobalization.GetTranslation(Properties.Resources.StdMessageCancelCurrentEdition), LibGlobalization.GetTranslation(Properties.Resources.StdCaptionCancel), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    this.userControlFeature.Clear();
                    this.panelContent.Children.RemoveAt(0);
                    this.panelContent.Children.Add(this.userControlFeature);
                }
            }
            else
            {
                this.panelContent.Children.Add(this.userControlFeature);
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
