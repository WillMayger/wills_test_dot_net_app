using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QA.Resources {
    public class ShoppingBasket {
        
        public ShoppingBasket():this(new List<BasketItem>()) { }

        private ShoppingBasket(List<BasketItem> currentBasket)
        {
            BasketItems = currentBasket;
        }

        private List<BasketItem> basketItems;

        //these properties enable me to use state to prevent the user from going to checkout when trying to adjust or remove any items
        //gets/sets whether it is being used (true for being used false for not)
        public bool adjusting_or_removing_item { get; set; }
        //gets/sets the action using it
        public string action_using { get; set; }
        //gets the id of the item
        public int adjusting_or_removing_id { get; set; }

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
                return decimal.Round(totalPrice, 2, MidpointRounding.AwayFromZero);
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

        public BasketItem GetItem(int ID, out bool does_it_contain)
        {
            BasketItem item = null;
            try
            {
                 
                item = basketItems.Single(p => p.ID == ID);
                does_it_contain = true;
            }
            catch (InvalidOperationException)
            {
            
                does_it_contain = false;
            }
            return item;
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
