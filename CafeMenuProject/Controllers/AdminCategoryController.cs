﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace CafeMenuProject.Controllers
{
    public class AdminCategoryController : Controller
    {
        private CategoryManager _category = new CategoryManager(new EfCategoryDal());


        public ActionResult Index()
        {
            var c = _category.GetList();
            return View(c);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category entity)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(entity);
            if (result.IsValid)
            {
                _category.CatagoryAdd(entity);
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

        public ActionResult Delete(int id)
        {
            var c = _category.GetById(id);

            if (c != null)
            {
                c.IsDeleted = !c.IsDeleted;
                _category.Update(c);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var c = _category.GetById(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult Update(Category entity)
        {
            _category.Update(entity);
            return RedirectToAction("Index");
        }
    }
}