using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using QA.Resources;


namespace OnlineShop.Controllers
{
    public class CheckoutController : Controller
    {
        IOnlineShopRepository onlineShopRepository;
        IStateRepository stateRepository;

        public CheckoutController()
            : this(new SQLOnlineShopRepository(), new SessionStateRepository())
        {
        }

        public CheckoutController(IOnlineShopRepository onlineShopRepository, IStateRepository stateRepository)
        {
            this.onlineShopRepository = onlineShopRepository;
            this.stateRepository = stateRepository;
        }

        //first page(or home page) of the Checkout controller
        public ActionResult Index()
        {
            ShoppingBasket shoppingBasket = stateRepository.GetShoppingBasket();
            //First checking if any user is currently trying to adjust or remove any item.
            if (shoppingBasket.adjusting_or_removing_item == true)
            {
                //if they are then they will be returned to the adjust or remove page they where on( uses the id of the item in the url to get
                // that specific item
                return Redirect(string.Format("/Basket/{0}/{1}", shoppingBasket.action_using, shoppingBasket.adjusting_or_removing_id));
            }
            Customer customer = new Customer();
            Decimal BasketTotal = stateRepository.GetShoppingBasket().BasketTotal;
            ViewBag.BasketTotal = BasketTotal;

            // if nothing is in there basket they will be redirected to the game page
            if (stateRepository.GetShoppingBasket().BasketItems.Count == 0) return RedirectToAction("Index", "Game");

            return View(customer);
        }

        // Partial method that is determining what needs to happen 
        // if they have submitted there information (this will be as a post) then they will be prompted with a confirmation page
        //if they have just clicked on checkout ( this will be a get) then they will be prompted with a page to fill in there infromation
        public PartialViewResult CheckoutPartial()
        {
            ShoppingBasket shoppingBasket = stateRepository.GetShoppingBasket();
           
            string checkout_or_confirmation;

            //if it is post they will be took to the confirmation page with a message.
            if (Request.HttpMethod.ToLower() == "post")
            {
                string first_name = Request["FirstName"];
                string last_name = Request["LastName"];
                string basket_total = shoppingBasket.BasketTotal.ToString();
                string card_number = Request["CardNumber"];

                //To Do
                //Add all of this information to db

                string last_four_digits = card_number.Substring(12);
                ViewBag.confirmation_message = string.Format("Thank you {0} {1} for placing your order with us £{2} has been debited from your card that ends with the following 4 digits:{3}",
                    first_name, last_name, basket_total, last_four_digits);

                shoppingBasket.EmptyBasket();
                checkout_or_confirmation = "PartialConfirmation";
            }
            //if not then they will be taken to the page to enter there information
            else
            {
                checkout_or_confirmation = "PartialCheckout";
            }
            ViewBag.order_total = shoppingBasket.BasketTotal;
            return PartialView(checkout_or_confirmation);
        }
    }
}
