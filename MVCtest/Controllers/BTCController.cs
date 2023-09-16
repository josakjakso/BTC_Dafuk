using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCtest.Data;
using MVCtest.Models;

namespace MVCtest.Controllers
{
    public class BTCController : Controller
    {
        private readonly BTCDBContext _USD;

        public BTCController(BTCDBContext USD)
        {
            _USD = USD;
        }

        public IActionResult Index()
        {
           IEnumerable <BTC> AllUSD = _USD.BTCs;


            return View(AllUSD);
        }

        public IActionResult Deposit()
        {
            ViewBag.AllUSD = _USD.BTCs;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(BTC obj)
        {
            if (ModelState.IsValid)
                {
                    obj.USD = Convert.ToDouble(String.Format("{0:0.00}", obj.USD));
                    _USD.BTCs.Add(obj);
                    _USD.SaveChanges();
                    return RedirectToAction("Index");
                }
            return RedirectToAction("Index");
         }

        
        public IActionResult Withdraw()
        {
            ViewBag.AllUSD = _USD.BTCs;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Withdraw(BTC obj)
        {

            obj.USD =  -obj.USD;

            if (ModelState.IsValid)
            {
                _USD.BTCs.Add(obj);
                _USD.SaveChanges();
                return RedirectToAction("Index");
            }
             return RedirectToAction("Index");
        }


        public IActionResult Buy()
        {
            ViewBag.AllUSD = _USD.BTCs;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buy(double price,double volum)
        {
            BTC obj = new BTC();
            double buyprice = price * volum;
            ViewBag.BuyPrice = buyprice;
            ViewBag.AllUSD = _USD.BTCs;
            obj.USD = -buyprice;
            obj.BTCUSD = volum;
            obj.Total = -buyprice;
            if (ModelState.IsValid)
            {
                _USD.BTCs.Add(obj);
                _USD.SaveChanges();
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }


        public IActionResult Sell()
        {
            ViewBag.AllUSD = _USD.BTCs;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sell(double price, double volum)
        {
            BTC obj = new BTC();
            double sellprice = price * volum;
            ViewBag.sellPrice = sellprice;
            ViewBag.AllUSD = _USD.BTCs;
            obj.USD = sellprice;
            obj.BTCUSD = -volum;
            obj.Total = sellprice;
            if (ModelState.IsValid)
            {
                _USD.BTCs.Add(obj);
                _USD.SaveChanges();
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }

        public IActionResult Reset()
        {
            var allItems = _USD.BTCs.ToList();
            _USD.BTCs.RemoveRange(allItems);
            _USD.SaveChanges();

            return RedirectToAction("Index");
        }






    }
}
