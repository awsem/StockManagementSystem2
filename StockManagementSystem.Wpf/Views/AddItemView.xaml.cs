using StockManagementSystem.Wpf.Models;
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

namespace StockManagementSystem.Wpf.Views
{
    /// <summary>
    /// Interaction logic for AddItemView.xaml
    /// </summary>
    public partial class AddItemView : Window
    {
        MainViewModel _viewModel;
        public AddItemView(MainViewModel mainView)
        {
            InitializeComponent();
            _viewModel = mainView;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var item = new Item
            {
                Id = int.Parse(idTxtBox.Text),
                Name = nameTxtBox.Text,
                Description = descriptionTxtBox.Text,
                PurchasedOn = DateTime.Now.AddSeconds(- double.Parse(dateTxtBox.Text))
            };
            _viewModel.Items.Add(item);
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
