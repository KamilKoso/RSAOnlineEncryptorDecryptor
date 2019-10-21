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
        private MessageViewModel messageViewModel;

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
            MessageViewModel messageModel = new MessageViewModel() { d = rsa.d, e = rsa.e, n=rsa.n  };
            
            return PartialView("WalletDataPartialView", messageModel);
        }

        public PartialViewResult MessageEncoder()
        {
            
            return PartialView("EncodePartialView");
        }

        public PartialViewResult GetEncodedMessage(MessageViewModel messageView)
        {

            return PartialView("EncodeDataPartialView");
        }
    }
}