using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;



namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IRsaAlgorithm rsa;

       public HomeController(IRsaAlgorithm rsaAlgorithm)
        {
            this.rsa = rsaAlgorithm;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Wallet()
        {
            
            return PartialView("WalletPartialView");
        }

        public PartialViewResult GetWalletData()
        {
            //Each request causes creating new Controller model, which causes creating new RSAAlgorithm model, so key values
            //will be different each time thanks to setValues() method in RSAAlgorithm constructor
            WalletViewModel walletModel = new WalletViewModel() { d = rsa.d, e = rsa.e, n=rsa.n  };
            return PartialView("WalletDataPartialView",walletModel);
        }
    }
}