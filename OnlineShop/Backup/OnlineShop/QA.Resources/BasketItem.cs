using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace QA.Resources {
    public class BasketItem {
        internal BasketItem(int ID, string name, decimal unitPrice, int quantity)
        {
            this.ID = ID;
            this.Name = name;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
        }

        public int ID { get; set; }
        public string Name { get; set; }

        private int quantity;
        public int Quantity {
            get {
                return quantity;
            }
            set {
                if (value <= 0)
                {
                    
                    throw new Exception("Quantity must be greater than zero");
                }
                quantity = value;               
            }
        }
       
        public decimal UnitPrice { get; set; }
        public decimal ItemTotal {
            get { return UnitPrice * Quantity; }
        }
    }
}
