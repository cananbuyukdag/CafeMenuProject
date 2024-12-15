using BusinessLayer.Concrete;
using BusinessLayer.Validationrules;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace CafeMenuProject.Controllers
{
    public class AdminPropertyController : Controller
    {
        private PropertyManager _property = new PropertyManager(new EfPropertyDal());


        public ActionResult Index()
        {
            var c = _property.GetList();
            return View(c);
        }

        [HttpGet]
        public ActionResult PropertyAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PropertyAdd(Property entity)
        {
            PropertyValidator validator = new PropertyValidator();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                _property.PropertyAdd(entity);
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


        [HttpGet]
        public ActionResult Update(int id)
        {
            var c = _property.GetById(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult Update(Property entity)
        {
            _property.Update(entity);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            var _id = id ?? 0;
            var p = _property.GetById(_id);
            _property.Delete(p);
            return RedirectToAction("Index");
        }
    }
}