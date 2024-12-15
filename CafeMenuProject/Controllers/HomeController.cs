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
        private ProductPropertyManager _productProperty = new ProductPropertyManager(new EfProductPropertyDal());
        private PropertyManager _property = new PropertyManager(new EfPropertyDal());
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
            var productProperty = _productProperty.GetList();
            var property = _property.GetList();

            var model = (from p in products
                         join c in categories on p.CategoryId equals c.CategoryId
                         join pp in productProperty.DefaultIfEmpty() on p.ProductId equals pp.ProductId into groupedProperties
                         from pp in groupedProperties.DefaultIfEmpty()
                         join pr in property.DefaultIfEmpty() on pp?.PropertyId equals pr?.PropertyId into prGrouped
                         from pr in prGrouped.DefaultIfEmpty()
                         group pr by new
                         {
                             p.ProductId,
                             p.ProductName,
                             p.ImagePath,
                             p.Price,
                             p.IsDeleted,
                             p.CategoryId,
                             c.CategoryName
                         } into groupedProperties
                         select new Models.ProductCategoryViewModel
                         {
                             ProductId = groupedProperties.Key.ProductId,
                             ProductName = groupedProperties.Key.ProductName,
                             ImagePath = groupedProperties.Key.ImagePath,
                             Price = groupedProperties.Key.Price,
                             IsDeleted = groupedProperties.Key.IsDeleted,
                             CategoryId = groupedProperties.Key.CategoryId,
                             CategoryName = groupedProperties.Key.CategoryName,
                             PropertyName = groupedProperties.Select(g => g?.Key + " " + g?.Value).ToList()
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