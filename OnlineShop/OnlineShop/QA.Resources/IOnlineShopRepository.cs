using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QA.Resources;
using OnlineShop.Models;

namespace QA.Resources
{
    public interface IOnlineShopRepository
    {
        // Display games
        IEnumerable<Game> GetAllGames();
        Game GetGameByGameID(int gameID);

        //For use at order confirmation to "add order to database"
        bool ProcessOrder(Customer customer, ShoppingBasket basket);
    }
}
