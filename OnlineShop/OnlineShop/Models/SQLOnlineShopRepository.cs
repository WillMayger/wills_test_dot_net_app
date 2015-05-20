using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QA.Resources;

namespace OnlineShop.Models
{
    public class SQLOnlineShopRepository : IOnlineShopRepository
    {
        OnlineShopEntities shopDB = new OnlineShopEntities();

        public SQLOnlineShopRepository() : this(new OnlineShopEntities())
        {
        }

        internal SQLOnlineShopRepository(OnlineShopEntities _shopDB)
        {
            shopDB = _shopDB;
        }

        IEnumerable<Game> IOnlineShopRepository.GetAllGames()
        {
            return shopDB.Games.ToList();
        }

        Game IOnlineShopRepository.GetGameByGameID(int gameID)
        {
            return shopDB.Games.SingleOrDefault(e => e.GameID == gameID);
        }

        bool IOnlineShopRepository.ProcessOrder(Customer customer, ShoppingBasket basket)
        {
            throw new NotImplementedException();
        }
    }
}