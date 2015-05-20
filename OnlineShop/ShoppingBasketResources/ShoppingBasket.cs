using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QA.ShoppingBasketResources {
    public class ShoppingBasket {
        
        public ShoppingBasket():this(new List<BasketItem>()) { }

        private ShoppingBasket(List<BasketItem> currentBasket)
        {
            BasketItems = currentBasket;
        }

        private List<BasketItem> basketItems;

        public List<BasketItem> BasketItems
        {
            get { return basketItems; }
            private set { basketItems = value; }
        }
        
        public decimal BasketTotal {
            get {
                decimal totalPrice = 0;
                foreach (BasketItem item in BasketItems)
	            {
		            totalPrice += item.ItemTotal;   
	            }
                return totalPrice;
            }
        }

        public void AddItem(int ID, string name, decimal unitPrice, int addQuantity) {
            bool found = false;
            foreach (BasketItem item in BasketItems)
            {
                if (item.ID == ID) {
                    item.Quantity = item.Quantity + addQuantity;
                    item.UnitPrice = unitPrice;
                    found = true;
                    break;
                }
            }
            if (!found) {
                BasketItems.Add(new BasketItem(ID, name, unitPrice, addQuantity));
            }
        }

        public bool RemoveItem(int ID)
        {
            try
            {
                BasketItem item = basketItems.Single(p => p.ID == ID);
                basketItems.Remove(item);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public BasketItem GetItem(int ID)
        {
            return basketItems.Single(p => p.ID == ID);
        }

        public bool AdjustItemQuantity(int ID, int quantity)
        {
            try
            {
                BasketItem item = basketItems.Single(p => p.ID == ID);
                item.Quantity =quantity;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void EmptyBasket() {
            BasketItems.Clear();
        }
    }
}
