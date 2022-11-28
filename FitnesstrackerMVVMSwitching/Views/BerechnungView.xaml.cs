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
    /// Interaktionslogik für BerechnungView.xaml
    /// </summary>
    public partial class BerechnungView : Window
    {
        public BerechnungView()
        {
            InitializeComponent();
        }

       
      

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is BerechnungViewModel.ICloseWindows vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
    }
}
