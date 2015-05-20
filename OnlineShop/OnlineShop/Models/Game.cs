using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace OnlineShop.Models
{
    public class Game
    {
        //model that will be being filled by the db

        public int GameID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Unit Price")]
        public Decimal UnitPrice { get; set; }
        [DisplayName("Units In Stock")]
        public int UnitsInStock { get; set; }
        public int Position { get; set; }
    }
  
}