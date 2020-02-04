using StockManagementSystem.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace StockManagementSystem.Wpf.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Item> _items;

        private Item _selectedItem;

        DispatcherTimer _dispatcherTimer;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Item> _outOfStockItems;
        public ObservableCollection<Item> OutOfStockItems
        {
            get { return _outOfStockItems; }
            set { _outOfStockItems = value; }
        }

        public MainViewModel()
        {

            _dispatcherTimer = new DispatcherTimer(DispatcherPriority.Background);
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(5);
            _dispatcherTimer.Tick += dispatcherTimer_Tick;
            _dispatcherTimer.Start();

            OutOfStockItems = new ObservableCollection<Item>();

            Items = new ObservableCollection<Item>()
            {
                new Item
                {
                    Id=0,
                    Name= "Mac and Cheese",
                    Description="Macaroni and cheese—also called mac and cheese or mac n cheese in US \n" +
                    "and Canadian English, macaroni cheese in the United Kingdom—is a dish of English\n " +
                    "origin, consisting of cooked macaroni pasta and a cheese sauce, most commonly cheddar.\n",
                    PurchasedOn = DateTime.Now.AddSeconds(-20)
                },
                new Item
                {
                    Id=1,
                    Name= "Sausages",
                    Description="The hot dog or dog is a grilled or steamed sausage sandwich where \n" +
                    "the sausage is served in the slit of a partially sliced bun. It can also refer to\n" +
                    "the sausage itself. The sausage used is the wiener or frankfurter. \n" +
                    "The names of these sausages also commonly refer to their assembled sandwiches\n",
                    PurchasedOn = DateTime.Now.AddSeconds(-30)
                },
                new Item
                {
                    Id=2,
                    Name= "Oreo",
                    Description="An Oreo is a sandwich cookie consisting of two \n" +
                    "wafers with a sweet crème filling. Introduced in 1912, Oreo is the\n" +
                    "best selling cookie brand in the United States. As of 2018, the \n" +
                    "version sold in the U.S.\n" +
                    "is made by the Nabisco division of Mondelez International.\n",
                    PurchasedOn = DateTime.Now.AddSeconds(-40)
                }
            };
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Items.Where(x => x.IsOutOfStock)
                .ToList()
                .ForEach(x =>
                {
                    if (!OutOfStockItems.Contains(x))
                    {
                        OutOfStockItems.Add(x);
                    }
                });
        }
    }
}
