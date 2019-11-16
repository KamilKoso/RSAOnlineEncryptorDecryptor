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
            
            if (ModelState.IsValid)
            {
                List<int> encodedLetters = rsa.EncodeMessage(messageView.message, messageView.n, messageView.e);
                return PartialView("EncodeDataPartialView", encodedLetters);
            }
            else
            {
                return PartialView("EncodeDataPartialView");
            }
        }

        public PartialViewResult MessageDecoder()
        {

            return PartialView("DecodePartialView");
        }

        public PartialViewResult GetDecodedMessage(DecodeMessageViewModel messageToDecode)
        {
            if (ModelState.IsValid)
            {
                while(messageToDecode.EncodedMessage[messageToDecode.EncodedMessage.Length-1] == ' ')
                   messageToDecode.EncodedMessage=messageToDecode.EncodedMessage.Remove(messageToDecode.EncodedMessage.Length - 1); //Removes space if there is any at the end of given string

                string message = rsa.DecodeMessage(messageToDecode.StringParser(messageToDecode.EncodedMessage), messageToDecode.n, messageToDecode.d);
                return PartialView("DecodedDataPartialView", message);
            }
            else
                return PartialView("DecodedDataPartialView");
        }
    }
}