using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Wpf.Models
{
    public class Item 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public DateTime PurchasedOn { get; set; }

        public bool IsOutOfStock { 
            get 
            {
                return (DateTime.Now - PurchasedOn).TotalMinutes > 1;
            } 
        }
    }
}
