using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QA.Resources;

namespace OnlineShop.Models
{
    public class SessionStateRepository:IStateRepository
    {
        ShoppingBasket IStateRepository.GetShoppingBasket()
        {
            HttpContext context = HttpContext.Current;
            ShoppingBasket shoppingBasket = context.Session["ShoppingBasket"] as ShoppingBasket;

            //if userDetail does not exist it must be the first time its being asked for it needs one creating
            if (shoppingBasket == null)
            {
                shoppingBasket = new ShoppingBasket();
                context.Session["ShoppingBasket"] = shoppingBasket;
            }
            return shoppingBasket;
        }
    }
}