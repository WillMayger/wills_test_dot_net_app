using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OnlineShop.Models;

namespace QA.Resources
{
    public class OnlineShopEntities:DbContext
    {
        public DbSet<Game> Games { get; set; }
    }
}