using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QA.ShoppingBasketResources;

namespace OnlineShop.Models
{
    public class OnlineShopRepository:IOnlineShopRepository
    {
        OnlineShopEntities shopDB = new OnlineShopEntities();
        //Links to Games table in QAGaMes Database via Entity Framework
        IEnumerable<Game> IOnlineShopRepository.GetAllGames()
        {
            return shopDB.Games.ToList();
        }

        Game IOnlineShopRepository.GetGameByGameID(int gameID)
        {
            return shopDB.Games.Single(g => g.GameID == gameID);
        }

        //Links to shopping basket via Session State
        void IOnlineShopRepository.AddItemToBasket(Game game)
        {
            ShoppingBasket basket = GetBasket();
            basket.AddItem(game.GameID, game.Name, game.UnitPrice, 1);
        }

        void IOnlineShopRepository.RemoveItemFromBasket(int gameID)
        {
            ShoppingBasket basket = GetBasket();
            basket.RemoveItem(gameID);
        }

        List<BasketItem> IOnlineShopRepository.GetBasketItems()
        {
            ShoppingBasket basket = GetBasket();
            return basket.BasketItems;
        }

        BasketItem IOnlineShopRepository.GetBasketItem(int gameID)
        {
            ShoppingBasket basket = GetBasket();
            return basket.GetItem(gameID);
        }

        void IOnlineShopRepository.AdjustItemQuantity(int gameID, int quantity)
        {
            ShoppingBasket basket = GetBasket();
            basket.AdjustItemQuantity(gameID, quantity);
        }

        decimal IOnlineShopRepository.GetOrderTotal()
        {
            ShoppingBasket basket = GetBasket();
            return basket.BasketTotal;
        }

        bool IOnlineShopRepository.BasketIsEmpty
        {
            get
            {
                ShoppingBasket basket = GetBasket();
                if (basket.BasketItems.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        bool IOnlineShopRepository.ProcessOrder(Customer customer)
        {
            ShoppingBasket basket = GetBasket();
            //process the order - add details to database etc.
            //Would be done here
             

            //Empty the basket
            basket.EmptyBasket();
            return true;
        }

        //Gets reference to shopping basket object held in session state or
        //create a new shopping basket and adds it to session state
        private static ShoppingBasket GetBasket()
        {
            HttpContext context = System.Web.HttpContext.Current;
            ShoppingBasket basket = context.Session["Basket"] as ShoppingBasket;
            if (basket == null)
            {
                context.Session["Basket"] = new ShoppingBasket();
                basket = context.Session["Basket"] as ShoppingBasket;
            }
            return basket;
        }



    }
}