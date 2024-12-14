using BusinessLayer.Concrete;
using CafeMenuProject.Models;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Newtonsoft.Json.Linq;
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

            var model = (from p in products
                         join c in categories on p.CategoryId equals c.CategoryId
                         select new Models.ProductCategoryViewModel
                         {
                             ProductId = p.ProductId,
                             ProductName = p.ProductName,
                             ImagePath = p.ImagePath,
                             Price = p.Price,
                             IsDeleted = p.IsDeleted,
                             CategoryId = p.CategoryId,
                             CategoryName = c.CategoryName,
                         }).ToList();
            
            return View(model);

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