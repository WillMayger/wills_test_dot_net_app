using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QA.ShoppingBasketResources;

namespace QA.ShoppingBasketResources
{
    public interface IOnlineShopRepository
    {
        IEnumerable<IGame> GetAllGames();
        IGame GetGameByGameID(int gameID);

        void AddItemToBasket(IGame game);
        void AdjustItemQuantity(int gameID, int quantity);
        bool BasketIsEmpty{get;}
        List<QA.ShoppingBasketResources.BasketItem> GetBasketItems();
        BasketItem GetBasketItem(int gameID);
        decimal GetOrderTotal();
        void RemoveItemFromBasket(int gameID);


        //For use at order confirmation to "add order to database"
        bool ProcessOrder(Customer customer);
    }
}
