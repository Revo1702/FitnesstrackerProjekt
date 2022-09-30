using FitnesstrackerMVVMSwitching.ViewModels;
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

namespace FitnesstrackerMVVMSwitching.Views
{
    /// <summary>
    /// Interaktionslogik für TrainingssessionView.xaml
    /// </summary>
    public partial class TrainingssessionView : Window
    {
        public TrainingssessionView()
        {
            InitializeComponent();
            Loaded += TrainingssessionViewLoaded;
        }
        private void TrainingssessionViewLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is TrainingssessionViewModel.ICloseWindows vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
    }
}
