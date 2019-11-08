using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;
using System.Numerics;



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
            return PartialView("WalletDataPartialView", walletModel);
        }

        public PartialViewResult MessageEncoder()
        {
            
            return PartialView("EncodePartialView");
        }

        public PartialViewResult GetEncodedMessage(MessageViewModel messageView)
        {
            
            if (ModelState.IsValid && messageView!=null)
            {
                List<int> encodedLetters = rsa.EncodeMessage(messageView.message, messageView.n, messageView.e);
                return PartialView("EncodeDataPartialView", encodedLetters);
            }
            else
            {
                return PartialView("EncodeDataPartialView");
            }
        }
    }
}