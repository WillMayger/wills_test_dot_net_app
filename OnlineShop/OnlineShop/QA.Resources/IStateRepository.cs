using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QA.Resources
{
    public interface IStateRepository
    {
        //Get Shopping Basket
        ShoppingBasket GetShoppingBasket();
    }
}
