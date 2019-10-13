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
      private IRsaAlgorithm rsa= new RSAAlgorithm();

       // HomeController(IRsaAlgorithm rsaAlgorithm)
        //{
       //     this.rsa = rsaAlgorithm;
       // }

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
            
            WalletViewModel walletModel = new WalletViewModel() { d = rsa.d, e = rsa.e, n=rsa.n  };
            return PartialView("WalletDataPartialView",walletModel);
        }
    }
}