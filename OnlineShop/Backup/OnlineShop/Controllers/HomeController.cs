using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;
using QA.Resources;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        IOnlineShopRepository onlineShopRepository;
        IStateRepository stateRepository;

        public HomeController()
            : this(new SQLOnlineShopRepository(), new SessionStateRepository())
        {
        }

        public HomeController(IOnlineShopRepository onlineShopRepository, IStateRepository stateRespository)
        {
            this.onlineShopRepository = onlineShopRepository;
            this.stateRepository = stateRespository;
        }        
        
        //
        //Home page overall
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the QA Games Online Shop!";
            ViewBag.Title = "QA Games Online Shop";
            return View();
        }
    
    }
}
