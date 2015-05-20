using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using QA.Resources;

namespace OnlineShop.Controllers
{
    public class BasketController : Controller
    {
        IOnlineShopRepository onlineShopRepository;
        IStateRepository stateRepository;

        public BasketController()
            : this(new SQLOnlineShopRepository(), new SessionStateRepository())
        {
        }

        public BasketController(IOnlineShopRepository onlineShopRepository, IStateRepository stateRepository)
        {
            this.onlineShopRepository = onlineShopRepository;
            this.stateRepository = stateRepository;
        }

        //first page(or home page) of the Basket controller
        public ActionResult Index()
        {
            ShoppingBasket shoppingBasket = stateRepository.GetShoppingBasket();

            IEnumerable<BasketItem> users_games = shoppingBasket.BasketItems;

            ViewBag.TotalBasketCost = shoppingBasket.BasketTotal;

            

            return View(users_games);
        }

        //partial view method that determines which partial view gets used depending on the amount of items in the shopping basket
        public PartialViewResult IndexPartial()
        {
            ShoppingBasket shoppingBasket = stateRepository.GetShoppingBasket();

            IEnumerable<BasketItem> users_games = shoppingBasket.BasketItems;
            string count_or_no_count;
            ViewBag.Message = "";
            if (users_games.Count() == 0)
            {
                count_or_no_count = "PartialBasketNoItems";
            }
            else
            {
                count_or_no_count = "PartialBasketWithItems";
            }

            ViewBag.TotalBasketCost = shoppingBasket.BasketTotal;
            return PartialView(count_or_no_count, users_games);
        }
        
        //get that gets the id and prompts the user to confirm the amount of which they want to adjust that item
        [HttpGet]
        public ActionResult AdjustQuantity(int id)
        {

            ShoppingBasket shoppingBasket = stateRepository.GetShoppingBasket();
            shoppingBasket.action_using = "AdjustQuantity";
            shoppingBasket.adjusting_or_removing_item = true;
            shoppingBasket.adjusting_or_removing_id = id;
            BasketItem game = shoppingBasket.GetItem(id);

            ViewBag.game_id = id;

            return View(game);
        }

        //post that processes the adjust quantity
        [HttpPost]
        public ActionResult AdjustQuantity()
        {
            int id = Convert.ToInt32(Request["Game_ID"]);
            int ReplacementValue = Convert.ToInt32(Request["Quantity"]);
            ShoppingBasket shoppingBasket = stateRepository.GetShoppingBasket();
            shoppingBasket.AdjustItemQuantity(id, ReplacementValue);

            shoppingBasket.action_using = "";
            shoppingBasket.adjusting_or_removing_item = false;
            shoppingBasket.adjusting_or_removing_id = 0;

            return RedirectToAction("Index");
        }

        //get that gets the id and prompts the user to confirm the removal of  that item
        [HttpGet]
        public ActionResult Remove(int id)
        {
            ShoppingBasket shoppingBasket = stateRepository.GetShoppingBasket();
            shoppingBasket.action_using = "Remove";
            shoppingBasket.adjusting_or_removing_item = true;
            shoppingBasket.adjusting_or_removing_id = id;
            BasketItem game = shoppingBasket.GetItem(id);
            ViewBag.game_id = id;
            return View(game);
        }

        //post that processes the removal of the item
        [HttpPost]
        public ActionResult Remove()
        {
            int id = Convert.ToInt32(Request["Game_ID"]);
            ShoppingBasket shoppingBasket = stateRepository.GetShoppingBasket();
            shoppingBasket.RemoveItem(id);

            shoppingBasket.action_using = "";
            shoppingBasket.adjusting_or_removing_item = false;
            shoppingBasket.adjusting_or_removing_id = 0;

           
            return RedirectToAction("Index");
        }

    }
}
