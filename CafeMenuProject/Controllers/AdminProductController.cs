using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.Validationrules;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace CafeMenuProject.Controllers
{
    public class AdminProductController : Controller
    {
        private ProductManager _product = new ProductManager(new EfProductDal());
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        private UserManager wm = new UserManager(new EfUserDal());

        public ActionResult Index()
        {
            var c = _product.GetList();
            return View(c);
        }

        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> valueItems = (from x in cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            ViewBag.Items = valueItems;
            return View();
        }

        [HttpPost]
        public ActionResult ProductAdd(Product entity, HttpPostedFileBase ImageUpload)
        {
            ProductValidator validator = new ProductValidator();
            ValidationResult result = validator.Validate(entity);
            {
                if (ModelState.IsValid)
                {
                    if (ImageUpload != null && ImageUpload.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(ImageUpload.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadedImages/"), fileName);
                        ImageUpload.SaveAs(path);
                        entity.ImagePath = "/Images/" + fileName;

                    }
                    if (string.IsNullOrEmpty(entity.ImagePath))
                    {
                        ModelState.AddModelError("", "Mevcut resim yok, yeni bir resim yükleyin.");
                    }
                    entity.CreatedDate = DateTime.Now;
                    _product.ProductAdd(entity);
                    return RedirectToAction("Index");
                }

                return View(_product);
            }
        }
        public ActionResult Delete(int id)
        {
            var p = _product.GetById(id);

            if (p != null)
            {
                p.IsDeleted = !p.IsDeleted;
                _product.Update(p);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var categoryget = (from x in cm.GetList()
                               select new SelectListItem
                               {
                                   Text = x.CategoryName,
                                   Value = x.CategoryId.ToString()
                               }).ToList();

            ViewBag.Item = categoryget;
            var p = _product.GetById(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Update(Product entity, HttpPostedFileBase ImagePath)
        {
            ProductValidator validator = new ProductValidator();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                if (ImagePath != null && ImagePath.ContentLength > 0)
                {
                    var uploadDirectory = Server.MapPath("~/UploadedImages");
                    if (!Directory.Exists(uploadDirectory))
                    {
                        Directory.CreateDirectory(uploadDirectory);
                    }

                    var fileName = Path.GetFileName(ImagePath.FileName);
                    var path = Path.Combine(uploadDirectory, fileName);
                    ImagePath.SaveAs(path);

                    entity.ImagePath = fileName;
                }
                _product.Update(entity);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View();
        }
    }
}