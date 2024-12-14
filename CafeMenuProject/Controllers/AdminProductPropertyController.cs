using BusinessLayer.Concrete;
using CafeMenuProject.Models;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeMenuProject.Controllers
{
    public class AdminProductPropertyController : Controller
    {
        private ProductPropertyManager _pproperty = new ProductPropertyManager(new EfProductPropertyDal());
        private ProductManager _product = new ProductManager(new EfProductDal());
        private PropertyManager _property = new PropertyManager(new EfPropertyDal());

        public ActionResult Index()
        {
            var productProperties = _pproperty.GetList();
            var products = _product.GetList();
            var properties = _property.GetList();

            var model = (from pp in productProperties
                         join p in products on pp.ProductId equals p.ProductId
                         join pr in properties on pp.PropertyId equals pr.PropertyId
                         select new ProductPropertyViewModel
                         {
                             ProductPropertyId = pp.ProductProdpertyId,
                             ProductId = pp.ProductId,
                             ProductName = p.ProductName,
                             PropertyId = pp.PropertyId,
                             PropertyName = pr.Key + " " + pr.Value
                         }).ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult ProductPropertyAdd()
        {
            List<SelectListItem> valueProduct = (from x in _product.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.ProductName,
                                                   Value = x.ProductId.ToString()
                                               }).ToList();

            List<SelectListItem> valueProperty = (from p in _property.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = p.Key + " " + p.Value,
                                                    Value = p.PropertyId.ToString()
                                                }).ToList();

            ViewBag.Property = valueProperty;

            ViewBag.Product = valueProduct;
            return View();
        }

        [HttpPost]
        public ActionResult ProductPropertyAdd(ProductProperty entity)
        {
                _pproperty.ProductPropertyAdd(entity);
                return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> valueProduct = (from x in _product.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.ProductName,
                                                     Value = x.ProductId.ToString()
                                                 }).ToList();

            List<SelectListItem> valueProperty = (from p in _property.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = p.Key + " " + p.Value,
                                                      Value = p.PropertyId.ToString()
                                                  }).ToList();

            ViewBag.Property = valueProperty;

            ViewBag.Product = valueProduct;
            var pp = _pproperty.GetById(id);
            return View(pp);
        }

        [HttpPost]
        public ActionResult Update(ProductProperty entity)
        {
            if (entity == null || entity.ProductProdpertyId <= 0)
            {
                ModelState.AddModelError("", "Geçersiz veri.");
            }

            try
            {
                _pproperty.Update(entity);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu: " + ex.Message);
                return View(entity);
            }
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            var _id = id ?? 0;
            var p = _pproperty.GetById(_id);
            _pproperty.Delete(p);
            return RedirectToAction("Index");
        }
    }
}