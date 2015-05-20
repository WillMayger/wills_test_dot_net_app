using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using QA.Resources;

namespace OnlineShop.Controllers
{
    public class GameController : Controller
    {
        IOnlineShopRepository onlineShopRepository;
        IStateRepository stateRepository;

        public GameController()
            : this(new SQLOnlineShopRepository(), new SessionStateRepository())
        {
        }

        public GameController(IOnlineShopRepository onlineShopRepository, IStateRepository stateRespository)
        {
            this.onlineShopRepository = onlineShopRepository;
            this.stateRepository = stateRespository;
        }

        //home page for the game controller
        public ActionResult Index(string message = "")
        {
            // getting all games in the DB
            IEnumerable<Game> games = onlineShopRepository.GetAllGames();

            ViewBag.Message = message;

            return View(games);
        }

        //if the user adds an item to there basket
        public ActionResult Add(int id)
        {
            //getting the game by id
            Game game = onlineShopRepository.GetGameByGameID(id);

            //getting the seeeion state shoppingBasket
            ShoppingBasket shoppingBasket = stateRepository.GetShoppingBasket();

            bool does_it_contain;

            //getting the old game object with a boolean out parameter
            BasketItem old_game = shoppingBasket.GetItem(id, out does_it_contain);

            // checking to see if the game already exists in the shopping basket
            if (does_it_contain == true)
            {
                shoppingBasket.AdjustItemQuantity(id, old_game.Quantity + 1);
            }
            else
            {

                shoppingBasket.AddItem(id, game.Name, game.UnitPrice, 1);
            }

            //adding the message to the view that it has been added to the basket
            string message = string.Format("{0} has been added to your Shopping Basket", game.Name);


            //returning the View 
            return Index(message);

        }

    }
}
