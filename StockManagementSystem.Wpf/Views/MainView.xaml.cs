using StockManagementSystem.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace StockManagementSystem.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
    
        MainViewModel MainViewModel = new MainViewModel();
        public MainView()
        {
            InitializeComponent();
            DataContext = MainViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddItemView win2 = new AddItemView(MainViewModel);
            win2.Show(); 
        }
    }
}
