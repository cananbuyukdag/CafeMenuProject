using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CafeMenuProject.Controllers
{
    public class HomeController : Controller
    {
        private ProductManager _product = new ProductManager(new EfProductDal());
        private CategoryManager _category = new CategoryManager(new EfCategoryDal());
        private readonly ExchangeRateService _exchangeRateService;

        public HomeController()
        {
            _exchangeRateService = new ExchangeRateService();
        }

        public async Task<ActionResult> Index()
        {
            var exchangeRates = await _exchangeRateService.GetExchangeRatesAsync();
            ViewBag.UsdRate = exchangeRates.UsdRate;
            ViewBag.EuroRate = exchangeRates.EuroRate;

            var products = _product.GetList();
            var categories = _category.GetList();
            
            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}